using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geo.Data;
using Geo.Models;
using System.Dynamic;

namespace Geo.Controllers
{
    public class UserController : Controller
    {
        private readonly GeoContext _context;

        public UserController(GeoContext context)
        {
            _context = context;
        }

        #region generated crud code

        // GET: User
        public async Task<IActionResult> Index()
        {
              return _context.User != null ? 
                          View(await _context.User.ToListAsync()) :
                          Problem("Entity set 'GeoContext.User'  is null.");
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            var query = from Absence in _context.Absence
                        where Absence.UserRefId == id
                        select Absence;

            user.absences = query.ToList();

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fname,lname,daysVacation,daysSick,daysPersonal,daysLeft,comment")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,fname,lname,daysVacation,daysSick,daysPersonal,daysLeft,comment")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'GeoContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        #endregion

        public async Task<IActionResult> RequestAbsence(int id)
        {
            ViewBag.id = id;
            return View("Absence");
        }

        [HttpPost, ActionName("Request")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> requestAbsence([Bind("absenceReason, UserRefId")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                // retrieve the user
                //var user = await _context.User.FirstOrDefaultAsync(x => x.ID == absence.UserRefId);
                // add the absency to the database
                _context.Add(absence);

                // save the changes
                await _context.SaveChangesAsync();

                // redirect to the index
                return RedirectToAction(nameof(Index));
            }
            return View("Absence");
        }

        public async Task<IActionResult> ShowAllAbsence(int id)
        {
            List<ViewModel> models = new();

            

            var person = await _context.User.FirstOrDefaultAsync(x => x.ID == id);
            //var data = await _context.Absence.FirstOrDefaultAsync(z => z.UserRefId == id);

            var data = await _context.Absence.Where(t => t.UserRefId == id).ToListAsync();

            foreach (var item in data)
            {
                ViewModel model = new();
                model.absence = item;
                model.user = person;

                models.Add(model);
            }

            ViewBag.fullName = $"{person.fname} {person.lname}";

            return View(models);
        }
    }
}