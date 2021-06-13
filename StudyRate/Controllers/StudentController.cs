using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyRate.Domain;
using StudyRate.Domain.Entities;

namespace StudyRate.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDBContext _context;

        public StudentController(AppDBContext context)
        {
            _context = context;
        }

        public ActionResult Login(long index)
        {
            var student = _context.Students.FirstOrDefault(x => x.IdentificationCode == index);
            if (student != null)
            {
                Authorization.StudentId = student.Id;
                return RedirectToAction("Cabinet", "Student");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Cabinet()
        {
            int id = Authorization.StudentId;
            if (id == 0)
            {
                return NotFound();
            }

            var marks = _context.Marks
                .Include(c => c.Subject)
                .Include(c => c.ControlType)
                .Include(c => c.Student)
                .ThenInclude(c => c.Group)
                .ThenInclude(c => c.Specialty)
                .ThenInclude(c => c.Faculty);

            if (marks == null)
            {
                return NotFound();
            }

            Student student = _context.Students
                .Include(c => c.Group)
                .ThenInclude(c => c.Specialty)
                .ThenInclude(c => c.Faculty).FirstOrDefault(x => x.Id == id);

            // Рейтинг в університеті
            var scoredModel = marks.GroupBy(t => new { StudentID = t.StudentID })
                .Select(g => new { Average = g.Average(p => p.Score), Count = g.Count(), Id = g.Key.StudentID })
                .OrderByDescending(el => el.Average).ToList();

            ViewBag.Rating = Math.Round(scoredModel.FirstOrDefault(x => x.Id == id).Average, 3);

            var studentMarks = marks
                .Where(x => x.StudentID == id).OrderByDescending(x => x.Semester);

            for (int i = 0; i < scoredModel.Count; i++)
            {
                if (scoredModel[i].Id == id)
                {
                    ViewBag.UniversityRating = i + 1;
                    break;
                }
            }

            // Рейтинг в групі
            scoredModel = marks.Where(x => x.Student.GroupID == student.GroupID)
                .GroupBy(t => new { StudentID = t.StudentID })
                .Select(g => new { Average = g.Average(p => p.Score), Count = g.Count(), Id = g.Key.StudentID })
                .OrderByDescending(el => el.Average).ToList();

            for (int i = 0; i < scoredModel.Count; i++)
            {
                if (scoredModel[i].Id == id)
                {
                    ViewBag.GroupRating = i + 1;
                    break;
                }
            }

            // Рейтинг на потоці
            scoredModel = marks.Where(x => x.Student.Group.SpecialtyID == student.Group.SpecialtyID)
                .GroupBy(t => new { StudentID = t.StudentID })
                .Select(g => new { Average = g.Average(p => p.Score), Count = g.Count(), Id = g.Key.StudentID })
                .OrderByDescending(el => el.Average).ToList();

            for (int i = 0; i < scoredModel.Count; i++)
            {
                if (scoredModel[i].Id == id)
                {
                    ViewBag.SpecialtyRating = i + 1;
                    break;
                }
            }

            // Рейтинг на факультеті
            scoredModel = marks.Where(x => x.Student.Group.Specialty.FacultyID == student.Group.Specialty.FacultyID)
                .GroupBy(t => new { StudentID = t.StudentID })
                .Select(g => new { Average = g.Average(p => p.Score), Count = g.Count(), Id = g.Key.StudentID })
                .OrderByDescending(el => el.Average).ToList();

            for (int i = 0; i < scoredModel.Count; i++)
            {
                if (scoredModel[i].Id == id)
                {
                    ViewBag.FacultyRating = i + 1;
                    break;
                }
            }

            ViewBag.StudentId = id;
            ViewBag.FirstName = student.FirstName;
            ViewBag.LastName = student.LastName;

            return View(studentMarks);
        }
    }
}
