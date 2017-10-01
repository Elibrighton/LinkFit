using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LinkFit.Data;
using LinkFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LinkFit.Controllers
{
    [Authorize(Roles = "AthleteAdministrators")]
    public class AthletesController : Controller
    {
        private readonly CoachContext _context;
        private readonly ApplicationDbContext _appContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AthletesController(
            CoachContext context,
            ApplicationDbContext appContext,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _appContext = appContext;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: Athletes
        public async Task<IActionResult> Index()
        {
            var viewData = await _context.Athletes
                .Include(a => a.ProgramEnrollments)
                    .ThenInclude(a => a.TrainingProgram)
                .AsNoTracking().ToListAsync();

            return View(viewData);
        }

        // GET: Athletes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes
                .Include(a => a.ProgramEnrollments)
                    .ThenInclude(a => a.TrainingProgram)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (athlete == null)
            {
                return NotFound();
            }

            return View(athlete);
        }

        // GET: Athletes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Surname,FirstName,EnrollmentDate,Gender,EntrantCategory,DateOfBirth")] Athlete athlete)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(athlete);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(athlete);
        }

        // GET: Athletes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes.SingleOrDefaultAsync(m => m.ID == id);
            if (athlete == null)
            {
                return NotFound();
            }
            return View(athlete);
        }

        // POST: Athletes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athleteToUpdate = await _context.Athletes.SingleOrDefaultAsync(a => a.ID == id);
            if (await TryUpdateModelAsync<Athlete>(
                athleteToUpdate,
                "",
                a => a.FirstName, a => a.Surname, a => a.EnrollmentDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }

            return View(athleteToUpdate);
        }

        // GET: Athletes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (athlete == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(athlete);
        }

        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athlete = await _context.Athletes
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (athlete == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Athletes.Remove(athlete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool AthleteExists(int id)
        {
            return _context.Athletes.Any(e => e.ID == id);
        }
    }
}
