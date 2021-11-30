using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazorCurso.Shared.Entidades;

namespace BlazorCurso.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Generos
        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return Ok(await _context.Generos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FirstOrDefaultAsync(m => m.Id == id);
            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero);
        }

        // POST: Generos/Create
        [HttpPost]
        public async Task<ActionResult<int>> Create([Bind("Id,Nombre")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return Ok(genero.Id);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Genero genero)
        {
            _context.Attach(genero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Generos.AnyAsync(x => x.Id == id);

            if (!existe) { return NotFound(); }

            _context.Remove(new Genero { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool GeneroExists(int id)
        {
            return _context.Generos.Any(e => e.Id == id);
        }
    }
}
