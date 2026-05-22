using Employment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDbContext _context;

        public EmployeeController(MyDbContext context)
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
            //you can send the managerId to the view using (ViewBag or ViewData or TempData) and then use it in the view to set the MangerId property of the Employee model when creating a new employee.
            //or you can also pass the managerId as a parameter to the Create action and then set the MangerId property of the Employee model in the action method before returning the view.
            ViewBag.ManagerId = managerId;

            return View(new Employee
            {
                MangerId = managerId
            });
        }

        [HttpPost]
        public IActionResult Create(Employee employee, IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                string fileName = Path.GetFileName(ImageFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                employee.Image = fileName;
            }
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}
