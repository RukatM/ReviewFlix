using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReviewFlixAdmin.Data;
using ReviewFlixAdmin.Models;

namespace ReviewFlixAdmin.Controllers
{
    public class CastingsController : Controller
    {
        private readonly AppDbContext _context;

        public CastingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Castings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Castings.ToListAsync());
        }

        // GET: Castings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casting = await _context.Castings
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (casting == null)
            {
                return NotFound();
            }

            return View(casting);
        }

        // GET: Castings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Castings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmId,ActorId")] Casting casting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casting);
        }

        // GET: Castings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casting = await _context.Castings.FindAsync(id);
            if (casting == null)
            {
                return NotFound();
            }
            return View(casting);
        }

        // POST: Castings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmId,ActorId")] Casting casting)
        {
            if (id != casting.FilmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastingExists(casting.FilmId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(casting);
        }

        // GET: Castings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casting = await _context.Castings
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (casting == null)
            {
                return NotFound();
            }

            return View(casting);
        }

        // POST: Castings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casting = await _context.Castings.FindAsync(id);
            if (casting != null)
            {
                _context.Castings.Remove(casting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastingExists(int id)
        {
            return _context.Castings.Any(e => e.FilmId == id);
        }
    }
}
