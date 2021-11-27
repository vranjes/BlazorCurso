using BlazorCurso.Shared.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCurso.Client.Repositorios
{
    public interface IRepositorio
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        List<Pelicula> GetListaPeliculas();
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);
    }
}
