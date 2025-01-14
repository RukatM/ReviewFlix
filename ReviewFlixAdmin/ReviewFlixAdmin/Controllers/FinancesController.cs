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
    public class FinancesController : Controller
    {
        private readonly AppDbContext _context;

        public FinancesController(AppDbContext context)
        {
            _context = context;
        }


        // GET: Finances
        public async Task<IActionResult> Index()
        {
            var finances = await _context.Finances
                .Join(_context.Films,
                      finance => finance.FilmId,
                      film => film.Id,
                      (finance, film) => new
                      {
                          finance.Id,
                          finance.Budget,
                          finance.Revenue,
                          finance.FilmId,
                          FilmTitle = film.Title
                      })
                .ToListAsync();

            ViewBag.Finances = finances;

            return View();
        }


        // GET: Finances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finance = await _context.Finances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finance == null)
            {
                return NotFound();
            }

            return View(finance);
        }

        // GET: Finances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmId,Budget,Revenue")] Finance finance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finance);
        }

        // GET: Finances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finance = await _context.Finances.FindAsync(id);
            if (finance == null)
            {
                return NotFound();
            }
            return View(finance);
        }

        // POST: Finances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmId,Budget,Revenue")] Finance finance)
        {
            if (id != finance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceExists(finance.Id))
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
            return View(finance);
        }

        // GET: Finances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finance = await _context.Finances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finance == null)
            {
                return NotFound();
            }

            return View(finance);
        }

        // POST: Finances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finance = await _context.Finances.FindAsync(id);
            if (finance != null)
            {
                _context.Finances.Remove(finance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceExists(int id)
        {
            return _context.Finances.Any(e => e.Id == id);
        }
    }
}
