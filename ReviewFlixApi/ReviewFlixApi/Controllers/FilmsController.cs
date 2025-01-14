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
    public class FilmsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
        {
            return await _context.Films.ToListAsync();
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.Id)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{filmId}/reviews")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsForFilm(int filmId)
        {
            
            var reviews = await _context.Reviews
                .Where(r => r.FilmId == filmId)
                .ToListAsync();

            if (reviews == null || !reviews.Any())
            {
                return NotFound($"No reviews found for FilmId {filmId}");
            }

            return Ok(reviews);
        }

        [HttpGet("{filmId}/cast")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetCastForFilm(int filmId)
        {
            var cast = await _context.Castings
                .Where(c => c.FilmId == filmId)
                .Join(_context.Actors,
                      casting => casting.ActorId,
                      actor => actor.ActorId,
                      (casting, actor) => actor)
                .ToListAsync();

            if (!cast.Any())
            {
                return NotFound($"No cast found for FilmId {filmId}");
            }

            return Ok(cast);
        }

        [HttpGet("{filmId}/finance")]
        public async Task<ActionResult<Finance>> GetFinanceForFilm(int filmId)
        {
            var finance = await _context.Finances
                .FirstOrDefaultAsync(f => f.FilmId == filmId);

            if (finance == null)
            {
                return NotFound($"No finance data found for FilmId {filmId}");
            }

            return Ok(finance);
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
