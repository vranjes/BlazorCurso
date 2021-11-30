using BlazorCurso.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorCurso.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions opcionesPorDefectoJson = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public Repositorio( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Pelicula> GetListaPeliculas()
        {
            try
            {
                return new List<Pelicula>() { new Pelicula() { Titulo = "Origen", Lanzamiento = new DateTime(2015, 1, 1),Poster="https://pics.filmaffinity.com/inception-652954101-mmed.jpg" },
                                      new Pelicula() { Titulo = "1917", Lanzamiento = new DateTime(2021, 1, 1), Poster="https://pics.filmaffinity.com/1917-960418215-mmed.jpg" },
                                      new Pelicula() { Titulo = "Toy Story", Lanzamiento = new DateTime(1992, 1, 1),Poster="https://pics.filmaffinity.com/toy_story-626273371-mmed.jpg" },
                                      new Pelicula() { Titulo = "Tintin", Lanzamiento = new DateTime(2017, 1, 1) , Poster="https://pics.filmaffinity.com/the_adventures_of_tintin_secret_of_the_unicorn-152754707-mmed.jpg"} };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseWrapper< T>> Get<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHttp, opcionesPorDefectoJson);
                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHttp);
            }
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T,TResponse>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, enviarContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<TResponse>(responseHttp, opcionesPorDefectoJson);
                return new HttpResponseWrapper<TResponse>(response, false, responseHttp);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, true, responseHttp);
            }
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PutAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHttp = await _httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse,JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }
    }
}
