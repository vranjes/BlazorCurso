using BlazorCurso.Server.Helpers;
using BlazorCurso.Shared.DTOs;
using BlazorCurso.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : Controller
    {
        private ApplicationDbContext _context;
        private IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string contendor = "peliculas";

        public PeliculasController(ApplicationDbContext context, IAlmacenadorArchivos almacenadorArchivos)
        {
            _context = context;
            _almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<HomePageDTO>> Get()
        {
            var limite = 6;

            var peliculasEnCartelera = await _context.Peliculas.Where(x => x.EnCartelera).Take(limite).OrderByDescending(x => x.Lanzamiento).ToListAsync();

            var fechaActual = DateTime.Today;

            var proximosEstrenos = await _context.Peliculas.Where(x => x.Lanzamiento > fechaActual).Take(limite).OrderBy(x => x.Lanzamiento).ToListAsync();

            var response = new HomePageDTO()
            {
                PeliculasEnCartera = peliculasEnCartelera,
                ProximosEstrenos = proximosEstrenos
            };

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<Pelicula>> Post(Pelicula pelicula)
        {
            try
            {
                if (!string.IsNullOrEmpty(pelicula.Poster))
                {
                    var posterPelicula = Convert.FromBase64String(pelicula.Poster);
                    pelicula.Poster = await _almacenadorArchivos.GuardarArchivo(posterPelicula, ".jpg", contendor);
                }

                _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return Ok(pelicula.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
