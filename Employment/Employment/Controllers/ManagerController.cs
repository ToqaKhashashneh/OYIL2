using Employment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employment.Controllers
{
    public class ManagerController : Controller
    {
        private readonly MyDbContext _context;

        public ManagerController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var managers = _context.Managers.ToList();
            return View(managers);
        }


        public IActionResult Employees(int managerId)
        {
            var employees = _context.Employees.Where(e => e.MangerId == managerId).ToList();
            return View(employees);
        }

        
    }
}
