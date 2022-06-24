using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;

namespace Geo.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly GeoContext _context;

        public AbsenceController(GeoContext context)
        {
            _context = context;
        }

        // GET: Absence
        public async Task<IActionResult> Index()
        {
              return _context.Absence != null ? 
                          View(await _context.Absence.ToListAsync()) :
                          Problem("Entity set 'GeoContext.Absence'  is null.");
        }

        // GET: Absence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Absence == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .FirstOrDefaultAsync(m => m.id == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // GET: Absence/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Absence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,dateStart,dateEnd")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(absence);
        }

        // GET: Absence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Absence == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }
            return View(absence);
        }

        // POST: Absence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,dateStart,dateEnd")] Absence absence)
        {
            if (id != absence.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceExists(absence.id))
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
            return View(absence);
        }

        // GET: Absence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Absence == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .FirstOrDefaultAsync(m => m.id == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // POST: Absence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Absence == null)
            {
                return Problem("Entity set 'GeoContext.Absence'  is null.");
            }
            var absence = await _context.Absence.FindAsync(id);
            if (absence != null)
            {
                _context.Absence.Remove(absence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id)
        {
          return (_context.Absence?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
