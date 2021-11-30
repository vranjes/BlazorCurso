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
    public class PersonasController : Controller
    {
        private ApplicationDbContext _context;
        private IAlmacenadorArchivos _almacenadorArchivos;
        private IMapper _mapper;

        private readonly string contendor = "personas";
        public PersonasController(ApplicationDbContext context , IAlmacenadorArchivos almacenadorArchivos, IMapper mapper)
        {
            _context = context;
            _almacenadorArchivos = almacenadorArchivos;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        [HttpGet]
        public async Task<List<Persona>> Get([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Personas.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);

            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<List<Persona>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Persona>(); }

            return await _context.Personas.Where(p=>p.Nombre.ToLower().Contains(textoBusqueda.ToLower())).ToListAsync();
        }

        [HttpPost]
       public async Task<ActionResult<Persona>> Post(Persona persona)
        {
            try
            {
                if (!string.IsNullOrEmpty(persona.Foto))
                {
                    var fotoPersona = Convert.FromBase64String(persona.Foto);
                    persona.Foto = await _almacenadorArchivos.GuardarArchivo(fotoPersona, ".jpg", contendor);
                }

                _context.Add(persona);
                await _context.SaveChangesAsync();
                return Ok(persona.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {
            var personaAActualizar = await _context.Personas.FirstOrDefaultAsync(x => x.Id == persona.Id);

            if(personaAActualizar == null)
            {
                return NotFound();
            }

            //En este mapeo estamos ignorando la propiedad foto
            personaAActualizar = _mapper.Map(persona, personaAActualizar);

            //Si no es vacío elimino la foto anterior y guardo la nueva foto
            if (!string.IsNullOrWhiteSpace(persona.Foto))
            {

                //Elimino la imagen anterior, si existe
                if (personaAActualizar.Foto != null)
                    await _almacenadorArchivos.EliminarArchivo(personaAActualizar.Foto,contendor);

                //Guardo la nueva imagen
                var fotoImagen = Convert.FromBase64String(persona.Foto);
                personaAActualizar.Foto = await _almacenadorArchivos.EditarArchivo(fotoImagen, "jpg",contendor,persona.Foto);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Personas.AnyAsync(x => x.Id == id);

            if (!existe) { return NotFound(); }

            _context.Remove(new Persona { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool GeneroExists(int id)
        {
            return _context.Generos.Any(e => e.Id == id);
        }
    }
}
