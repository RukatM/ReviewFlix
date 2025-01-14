using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewFlixApi.Data;
using ReviewFlixApi.Models;

namespace ReviewFlixApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CastingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Castings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Casting>>> GetCastings()
        {
            return await _context.Castings.ToListAsync();
        }

        // GET: api/Castings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Casting>> GetCasting(int id)
        {
            var casting = await _context.Castings.FindAsync(id);

            if (casting == null)
            {
                return NotFound();
            }

            return casting;
        }

        // PUT: api/Castings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasting(int id, Casting casting)
        {
            if (id != casting.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(casting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CastingExists(id))
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

        // POST: api/Castings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Casting>> PostCasting(Casting casting)
        {
            _context.Castings.Add(casting);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CastingExists(casting.FilmId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCasting", new { id = casting.FilmId }, casting);
        }

        // DELETE: api/Castings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCasting(int id)
        {
            var casting = await _context.Castings.FindAsync(id);
            if (casting == null)
            {
                return NotFound();
            }

            _context.Castings.Remove(casting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CastingExists(int id)
        {
            return _context.Castings.Any(e => e.FilmId == id);
        }
    }
}
