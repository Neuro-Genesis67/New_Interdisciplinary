using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interdisciplinary.Data;
using Interdisciplinary.Models;

namespace Interdisciplinary.Controllers
{
    public class ShowController : Controller
    {
        private readonly InterdisciplinaryContext _context;

        public ShowController(InterdisciplinaryContext context)
        {
            _context = context;
        }

        // GET: Show
        public async Task<IActionResult> Index()
        {
            var interdisciplinaryContext = _context.Shows.Include(s => s.Admin).Include(s => s.Genre);
            return View(await interdisciplinaryContext.ToListAsync());
        }

        // GET: Show/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Admin)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Show/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "Password");
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId");
            return View();
        }

        // POST: Show/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,Title,AvailableTickets,Price,Date,ImageUrl,GenreId,AdminId")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "Password", show.AdminId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", show.GenreId);
            return View(show);
        }

        // GET: Show/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "Password", show.AdminId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", show.GenreId);
            return View(show);
        }

        // POST: Show/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowId,Title,AvailableTickets,Price,Date,ImageUrl,GenreId,AdminId")] Show show)
        {
            if (id != show.ShowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.ShowId))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "Password", show.AdminId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", show.GenreId);
            return View(show);
        }

        // GET: Show/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Admin)
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(m => m.ShowId == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Show/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.ShowId == id);
        }
    }
}
