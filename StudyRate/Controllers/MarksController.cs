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
    public class MarksController : Controller
    {
        private readonly AppDBContext _context;

        public MarksController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Marks.Include(m => m.ControlType).Include(m => m.Student).Include(m => m.Subject);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.ControlType)
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["ControlTypeID"] = new SelectList(_context.ControlTypes, "Id", "Name");
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id");
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,SubjectID,ControlTypeID,Score,Semester,DateAdded,Id")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ControlTypeID"] = new SelectList(_context.ControlTypes, "Id", "Name", mark.ControlTypeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", mark.StudentID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name", mark.SubjectID);
            return View(mark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["ControlTypeID"] = new SelectList(_context.ControlTypes, "Id", "Name", mark.ControlTypeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", mark.StudentID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name", mark.SubjectID);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,SubjectID,ControlTypeID,Score,Semester,DateAdded,Id")] Mark mark)
        {
            if (id != mark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
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
            ViewData["ControlTypeID"] = new SelectList(_context.ControlTypes, "Id", "Name", mark.ControlTypeID);
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", mark.StudentID);
            ViewData["SubjectID"] = new SelectList(_context.Subjects, "Id", "Name", mark.SubjectID);
            return View(mark);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Marks
                .Include(m => m.ControlType)
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Marks.FindAsync(id);
            _context.Marks.Remove(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Marks.Any(e => e.Id == id);
        }
    }
}
