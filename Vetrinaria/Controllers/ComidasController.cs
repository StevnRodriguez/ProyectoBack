using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vetrinaria.Models;

namespace Vetrinaria.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ComidasController : ControllerBase
    {
        private readonly VeterinariaContext _context;

        public ComidasController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: api/Comidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comida>>> GetComidas()
        {
            if (_context.Comidas == null)
            {
                return NotFound();
            }
            return await _context.Comidas.ToListAsync();
        }

        // GET: api/Comidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comida>> GetComida(int id)
        {
            if (_context.Comidas == null)
            {
                return NotFound();
            }
            var comida = await _context.Comidas.FindAsync(id);

            if (comida == null)
            {
                return NotFound();
            }

            return comida;
        }

        // PUT: api/Comidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComida(int id, Comida comida)
        {
            if (id != comida.IdComida)
            {
                return BadRequest();
            }

            _context.Entry(comida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComidaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comida>> PostComida(Comida comida)
        {
            if (_context.Comidas == null)
            {
                return Problem("Entity set 'VetrinariaContext.Comidas'  is null.");
            }
            _context.Comidas.Add(comida);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComidaExists(comida.IdComida))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComida", new { id = comida.IdComida }, comida);
        }

        // DELETE: api/Comidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComida(int id)
        {
            if (_context.Comidas == null)
            {
                return NotFound();
            }
            var comida = await _context.Comidas.FindAsync(id);
            if (comida == null)
            {
                return NotFound();
            }

            _context.Comidas.Remove(comida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComidaExists(int id)
        {
            return (_context.Comidas?.Any(e => e.IdComida == id)).GetValueOrDefault();
        }
    }
}

