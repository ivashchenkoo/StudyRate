using Microsoft.AspNetCore.Mvc;
using StudyRate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRate.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly DataManager dataManager;

        public StatisticsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult BestStudents()
        {
            return View(dataManager.Marks.GetMarks()
                .OrderByDescending(el => el.Score));
        }
        
        public IActionResult GroupsRating()
        {
            return View(dataManager.Marks.GetMarks()
                .OrderByDescending(el => el.Score));
        }

        public IActionResult SpecialtyRating()
        {
            return View(dataManager.Marks.GetMarks()
                .OrderByDescending(el => el.Score));
        }

        public IActionResult UniversityRating()
        {
            return View(dataManager.Marks.GetMarks()
                .OrderByDescending(el => el.Score));
        }

    }
}
