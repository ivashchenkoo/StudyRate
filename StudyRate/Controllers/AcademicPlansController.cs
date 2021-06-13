using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain;
using StudyRate.Domain.Entities;

namespace StudyRate.Controllers
{
    public class AcademicPlansController : Controller
    {
        private readonly AppDBContext _context;

        public AcademicPlansController(AppDBContext context)
        {
            _context = context;
        }

        // GET: AcademicPlans
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.AcademicPlans.Include(a => a.Group).Include(a => a.Professor).Include(a => a.Subject);
            return View(await appDBContext.ToListAsync());
        }

        // GET: AcademicPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicPlan = await _context.AcademicPlans
                .Include(a => a.Group)
                .Include(a => a.Professor)
                .Include(a => a.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicPlan == null)
            {
                return NotFound();
            }

            return View(academicPlan);
        }

        // GET: AcademicPlans/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Email");
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        // POST: AcademicPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupID,SubjectID,ProfessorID,Hours,CourseWork,Semester,Id")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Name", academicPlan.GroupID);
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Email", academicPlan.ProfessorID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name", academicPlan.SubjectID);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicPlan = await _context.AcademicPlans.FindAsync(id);
            if (academicPlan == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Name", academicPlan.GroupID);
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Email", academicPlan.ProfessorID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name", academicPlan.SubjectID);
            return View(academicPlan);
        }

        // POST: AcademicPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupID,SubjectID,ProfessorID,Hours,CourseWork,Semester,Id")] AcademicPlan academicPlan)
        {
            if (id != academicPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicPlanExists(academicPlan.Id))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Name", academicPlan.GroupID);
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Email", academicPlan.ProfessorID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name", academicPlan.SubjectID);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicPlan = await _context.AcademicPlans
                .Include(a => a.Group)
                .Include(a => a.Professor)
                .Include(a => a.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicPlan == null)
            {
                return NotFound();
            }

            return View(academicPlan);
        }

        // POST: AcademicPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicPlan = await _context.AcademicPlans.FindAsync(id);
            _context.AcademicPlans.Remove(academicPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicPlanExists(int id)
        {
            return _context.AcademicPlans.Any(e => e.Id == id);
        }
    }
}
