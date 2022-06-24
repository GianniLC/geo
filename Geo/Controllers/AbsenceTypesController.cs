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
    public class AbsenceTypesController : Controller
    {
        private readonly GeoContext _context;

        public AbsenceTypesController(GeoContext context)
        {
            _context = context;
        }

        // GET: AbsenceTypes
        public async Task<IActionResult> Index()
        {
              return _context.AbsenceTypes != null ? 
                          View(await _context.AbsenceTypes.ToListAsync()) :
                          Problem("Entity set 'GeoContext.AbsenceTypes'  is null.");
        }

        // GET: AbsenceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AbsenceTypes == null)
            {
                return NotFound();
            }

            var absenceTypes = await _context.AbsenceTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (absenceTypes == null)
            {
                return NotFound();
            }

            return View(absenceTypes);
        }

        // GET: AbsenceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AbsenceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] AbsenceTypes absenceTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absenceTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(absenceTypes);
        }

        // GET: AbsenceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AbsenceTypes == null)
            {
                return NotFound();
            }

            var absenceTypes = await _context.AbsenceTypes.FindAsync(id);
            if (absenceTypes == null)
            {
                return NotFound();
            }
            return View(absenceTypes);
        }

        // POST: AbsenceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] AbsenceTypes absenceTypes)
        {
            if (id != absenceTypes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absenceTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceTypesExists(absenceTypes.id))
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
            return View(absenceTypes);
        }

        // GET: AbsenceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AbsenceTypes == null)
            {
                return NotFound();
            }

            var absenceTypes = await _context.AbsenceTypes
                .FirstOrDefaultAsync(m => m.id == id);
            if (absenceTypes == null)
            {
                return NotFound();
            }

            return View(absenceTypes);
        }

        // POST: AbsenceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AbsenceTypes == null)
            {
                return Problem("Entity set 'GeoContext.AbsenceTypes'  is null.");
            }
            var absenceTypes = await _context.AbsenceTypes.FindAsync(id);
            if (absenceTypes != null)
            {
                _context.AbsenceTypes.Remove(absenceTypes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceTypesExists(int id)
        {
          return (_context.AbsenceTypes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
