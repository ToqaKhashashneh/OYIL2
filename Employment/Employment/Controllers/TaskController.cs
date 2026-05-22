using System;
using Employment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employment.Controllers
{
    public class TaskController : Controller
    {
        private readonly MyDbContext _context;

        public TaskController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create(int managerId)
        {
            ViewBag.ManagerId = managerId;
            ViewBag.Employees = new SelectList(_context.Employees.Where(Employees => Employees.MangerId == managerId).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(AssignTask task)
        {
            _context.AssignTasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
