using BlazorCurso.Server.Helpers;
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
        private readonly string contendor = "personas";
        public PersonasController(ApplicationDbContext context , IAlmacenadorArchivos almacenadorArchivos)
        {
            _context = context;
            _almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<List<Persona>> Get()
        {
            return await _context.Personas.ToListAsync();
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

    }
}
