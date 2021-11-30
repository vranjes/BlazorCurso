using AutoMapper;
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
        private IMapper _mapper;
        private readonly string contendor = "peliculas";

        public PeliculasController(ApplicationDbContext context, IAlmacenadorArchivos almacenadorArchivos,IMapper mapper)
        {
            _context = context;
            _almacenadorArchivos = almacenadorArchivos;
            _mapper = mapper;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<PelicularVisualizarDTO>> Get(int id)
        {
            var pelicula = await _context.Peliculas.Where(x => x.Id == id)
                                                    .Include(x => x.GenerosPelicula).ThenInclude(x => x.Genero)
                                                    .Include(x => x.PeliculaActor).ThenInclude(x => x.Persona)
                                                    .FirstOrDefaultAsync();

            if (pelicula == null) { return NotFound(); }

            //todo: sistema de votación
            var promedioVotos = 4;
            var votoUsuario = 5;

            pelicula.PeliculaActor = pelicula.PeliculaActor.OrderBy(x => x.Orden).ToList();

            var model = new PelicularVisualizarDTO()
            {
                Pelicula = pelicula,
                Generos = pelicula.GenerosPelicula.Select(x => x.Genero).ToList(),
                Actores = pelicula.PeliculaActor.Select(x => new Persona(){Id = x.Persona.Id,Nombre=x.Persona.Nombre,Foto = x.Persona.Foto,Personaje = x.Personaje}).ToList(),
                PromedioVotos = promedioVotos,
                VotoUsuario = votoUsuario
        };

            return model;
        }

        [HttpGet("actualizar/{id}")]
        public async Task<ActionResult<EditarPeliculaDTO>> PutGet (int id)
        {
            var peliculaActionResult = await Get(id);

            if(peliculaActionResult.Result is NotFoundResult) { return NotFound(); }

            var editarPeliculaDto = new EditarPeliculaDTO();

            editarPeliculaDto.Pelicula = peliculaActionResult.Value.Pelicula;
            editarPeliculaDto.ActoresSeleccionados = peliculaActionResult.Value.Actores;
            editarPeliculaDto.GenerosSeleccionados = peliculaActionResult.Value.Generos;
            editarPeliculaDto.GenerosNoSeleccionados = await _context.Generos.Where(x => !peliculaActionResult.Value.Generos.Contains(x)).ToListAsync();

            return Ok(editarPeliculaDto);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult<List<Pelicula>>> Get([FromQuery] ParametrosBusquedaPeliculas parametrosBusquedaPeliculas)
        {
            var peliculasQueryable = _context.Peliculas.AsQueryable();

            //Filtros
            if (!string.IsNullOrWhiteSpace(parametrosBusquedaPeliculas.Titulo))
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.Titulo.ToLower().Contains(parametrosBusquedaPeliculas.Titulo.ToLower()));
            }

            if (parametrosBusquedaPeliculas.EnCartelera)
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.EnCartelera);
            }

            if (parametrosBusquedaPeliculas.Estrenos)
            {
                var hoy = DateTime.Today;
                peliculasQueryable = peliculasQueryable.Where(x => x.Lanzamiento >= hoy);
            }
            if(parametrosBusquedaPeliculas.GeneroId > 0)
            {
                var generoSeleccionado = await _context.Generos.FirstOrDefaultAsync(x => x.Id == parametrosBusquedaPeliculas.GeneroId);
                if(generoSeleccionado != null)
                    peliculasQueryable = peliculasQueryable.Where(x => x.GenerosPelicula.Select(y=>y.GeneroId).Contains(parametrosBusquedaPeliculas.GeneroId));
            }

            // TODO:Implementar votación

            //Añado datos de paginacion a la cabecera
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(peliculasQueryable,parametrosBusquedaPeliculas.CantidadRegistros);

            var peliculas = await peliculasQueryable.Paginar(parametrosBusquedaPeliculas.Paginacion).ToListAsync();

            return peliculas;
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

                if (pelicula.PeliculaActor != null)
                {

                    for (int i = 0; i < pelicula.PeliculaActor.Count; i++)
                    {
                        pelicula.PeliculaActor[i].Orden = i + 1;
                    } 
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

        [HttpPut]
        public async Task<ActionResult> Put(Pelicula pelicula)
        {
            try
            {
                var peliculaAActualizar = await _context.Peliculas.FirstOrDefaultAsync(x => x.Id == pelicula.Id);

                if (peliculaAActualizar == null)
                {
                    return NotFound();
                }

                //En este mapeo estamos ignorando la propiedad poster
                peliculaAActualizar = _mapper.Map(pelicula, peliculaAActualizar);

                //Si no es vacío elimino la foto anterior y guardo la nueva foto
                if (!string.IsNullOrWhiteSpace(pelicula.Poster))
                {

                    //Elimino la imagen anterior, si existe
                    if (peliculaAActualizar.Poster != null)
                        await _almacenadorArchivos.EliminarArchivo(peliculaAActualizar.Poster, contendor);

                    //Guardo la nueva imagen
                    var posterImagen = Convert.FromBase64String(pelicula.Poster);
                    peliculaAActualizar.Poster = await _almacenadorArchivos.EditarArchivo(posterImagen, "jpg", contendor, pelicula.Poster);
                }

                //Borramos las listas de GenerosPeliculas y PeliculasActores
                await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM GenerosPeliculas WHERE PeliculaId={pelicula.Id}");
                await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM PeliculasActores WHERE PeliculaId={pelicula.Id}");

                //Añadimos el Orden para los actores
                if (pelicula.PeliculaActor != null)
                {

                    for (int i = 0; i < pelicula.PeliculaActor.Count; i++)
                    {
                        pelicula.PeliculaActor[i].Orden = i + 1;
                    }
                }

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Peliculas.AnyAsync(x => x.Id == id);

            if (!existe) { return NotFound(); }

            _context.Remove(new Pelicula { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public class ParametrosBusquedaPeliculas
        {
            public int Pagina { get; set; } = 1;
            public int CantidadRegistros { get; set; } = 5;
            public PaginacionDTO Paginacion
            {
                get { return new PaginacionDTO() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
            }
            public string Titulo { get; set; }
            public int GeneroId { get; set; }
            public bool EnCartelera { get; set; }
            public bool Estrenos { get; set; }
            public bool MasVotadas { get; set; }
        }
    }
}
