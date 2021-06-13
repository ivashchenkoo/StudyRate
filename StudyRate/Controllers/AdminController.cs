using Microsoft.AspNetCore.Mvc;
using StudyRate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRate.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDBContext _context;

        public AdminController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.Username == username && x.Password_hash == password);
            if (admin != null)
            {
                Authorization.AdminId = admin.Id;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
