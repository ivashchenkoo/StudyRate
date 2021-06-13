using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain;
using StudyRate.Domain.Entities;
using StudyRate.Service;

namespace StudyRate.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly AppDBContext _context;

        public ProfessorController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var professor = _context.Professors.FirstOrDefault(x => x.Email == email && x.PasswordHash == password);
            if (professor != null)
            {
                Authorization.ProffesorId = professor.Id;
                return RedirectToAction("Cabinet", "Professor");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Cabinet()
        {
            int id = Authorization.ProffesorId;
            if (id == 0)
            {
                return NotFound();
            }

            Professor professor = _context.Professors
                .Include(c => c.Position)
                .Include(c => c.Department)
                .ThenInclude(c => c.Faculty).FirstOrDefault(x => x.Id == id);

            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        public async Task<IActionResult> Edit()
        {
            int id = Authorization.ProffesorId;
            if (id == 0)
            {
                return NotFound();
            }

            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            ViewData["DepartmentID"] = new SelectList(_context.Departments, "Id", "Name", professor.DepartmentID);
            ViewData["PositionID"] = new SelectList(_context.Positions, "Id", "Name", professor.PositionID);

            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FirstName,MiddleName,LastName,PhoneNumber,PositionID,Email,PasswordHash,DepartmentID,Id")] Professor professor)
        {
            int id = Authorization.ProffesorId;
            if (id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
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
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "Id", "Name", professor.DepartmentID);
            ViewData["PositionID"] = new SelectList(_context.Positions, "Id", "Name", professor.PositionID);

            return View(professor);
        }

        public IActionResult Grades()
        {
            int id = Authorization.ProffesorId;
            if (id == 0)
            {
                return NotFound();
            }

            return View();
        }

        public IActionResult ImportGrades()
        {
            int id = Authorization.ProffesorId;
            if (id == 0)
            {
                return NotFound();
            }

            var academiPlan = _context.AcademicPlans
                .Include(x => x.Subject)
                .Include(x => x.Group)
                .Where(x => x.ProfessorID == id);
            var subjects = academiPlan.GroupBy(t => new { t.SubjectID, t.Subject.Name })
                .Select(g => new { Id = g.Key.SubjectID, g.Key.Name });
            var groups = academiPlan.GroupBy(t => new { t.GroupID, t.Group.Name })
                .Select(g => new { Id = g.Key.GroupID, g.Key.Name });
            var controlTypes = _context.ControlTypes;

            ViewData["SubjectID"] = new SelectList(subjects, "Id", "Name", subjects.FirstOrDefault().Name);
            ViewData["GroupID"] = new SelectList(groups, "Id", "Name", groups.FirstOrDefault().Name);
            ViewData["ControlTypeID"] = new SelectList(controlTypes, "Id", "Name", controlTypes.FirstOrDefault().Name);

            return View();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professors.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportGradesGSheet(int group, int subject, int controlType, string tableID, string sheet)
        {
            AcademicPlan academicPlan = _context.AcademicPlans.FirstOrDefault(x => x.GroupID == group && x.SubjectID == subject);

            GSheets gSheets = new(_context);
            var marks = gSheets.ReadEntries(tableID, sheet, academicPlan, controlType);

            if (marks == null || marks.Count == 0)
            {
                ViewBag.Message = "Помилка при імпортуванні з Гугл таблиць! Можливо таблиця пуста.";
                var academiPlan = _context.AcademicPlans
                    .Include(x => x.Subject)
                    .Include(x => x.Group)
                    .Where(x => x.ProfessorID == Authorization.ProffesorId);
                var subjects = academiPlan.GroupBy(t => new { t.SubjectID, t.Subject.Name })
                    .Select(g => new { Id = g.Key.SubjectID, g.Key.Name });
                var groups = academiPlan.GroupBy(t => new { t.GroupID, t.Group.Name })
                    .Select(g => new { Id = g.Key.GroupID, g.Key.Name });
                var controlTypes = _context.ControlTypes;

                ViewData["SubjectID"] = new SelectList(subjects, "Id", "Name", subjects.FirstOrDefault().Name);
                ViewData["GroupID"] = new SelectList(groups, "Id", "Name", groups.FirstOrDefault().Name);
                ViewData["ControlTypeID"] = new SelectList(controlTypes, "Id", "Name", controlTypes.FirstOrDefault().Name);

                return View("./ImportGrades");
            }

            _context.AddRange(marks);
            await _context.SaveChangesAsync();

            return View("/Views/Marks/Index.cshtml", marks);
        }

        [HttpPost("status")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportGradesExcel(int group, int subject, int controlType, [Bind("uploadedFile")] IFormFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                ViewBag.Message = "Помилка при імпортуванні з MS Excel! Файл не завантажено!";
                var academiPlan = _context.AcademicPlans
                    .Include(x => x.Subject)
                    .Include(x => x.Group)
                    .Where(x => x.ProfessorID == Authorization.ProffesorId);
                var subjects = academiPlan.GroupBy(t => new { t.SubjectID, t.Subject.Name })
                    .Select(g => new { Id = g.Key.SubjectID, g.Key.Name });
                var groups = academiPlan.GroupBy(t => new { t.GroupID, t.Group.Name })
                    .Select(g => new { Id = g.Key.GroupID, g.Key.Name });
                var controlTypes = _context.ControlTypes;

                ViewData["SubjectID"] = new SelectList(subjects, "Id", "Name", subjects.FirstOrDefault().Name);
                ViewData["GroupID"] = new SelectList(groups, "Id", "Name", groups.FirstOrDefault().Name);
                ViewData["ControlTypeID"] = new SelectList(controlTypes, "Id", "Name", controlTypes.FirstOrDefault().Name);

                return View("./ImportGrades");
            }

            AcademicPlan academicPlan = _context.AcademicPlans.FirstOrDefault(x => x.GroupID == group && x.SubjectID == subject);

            MSExcel mSExcel = new(_context);
            var marks = mSExcel.GetMarks(uploadedFile, academicPlan, controlType);

            if (marks == null || marks.Count == 0)
            {
                ViewBag.Message = "Помилка при імпортуванні з MS Excel! Можливо таблиця Excel пуста.";
                var academiPlan = _context.AcademicPlans
                    .Include(x => x.Subject)
                    .Include(x => x.Group)
                    .Where(x => x.ProfessorID == Authorization.ProffesorId);
                var subjects = academiPlan.GroupBy(t => new { t.SubjectID, t.Subject.Name })
                    .Select(g => new { Id = g.Key.SubjectID, g.Key.Name });
                var groups = academiPlan.GroupBy(t => new { t.GroupID, t.Group.Name })
                    .Select(g => new { Id = g.Key.GroupID, g.Key.Name });
                var controlTypes = _context.ControlTypes;

                ViewData["SubjectID"] = new SelectList(subjects, "Id", "Name", subjects.FirstOrDefault().Name);
                ViewData["GroupID"] = new SelectList(groups, "Id", "Name", groups.FirstOrDefault().Name);
                ViewData["ControlTypeID"] = new SelectList(controlTypes, "Id", "Name", controlTypes.FirstOrDefault().Name);

                return View("./ImportGrades");
            }

            _context.AddRange(marks);
            await _context.SaveChangesAsync();

            return View("/Views/Marks/Index.cshtml", marks);
        }
    }
}
