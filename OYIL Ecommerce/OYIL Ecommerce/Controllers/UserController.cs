using Microsoft.AspNetCore.Mvc;
using OYIL_Ecommerce.Models;

namespace OYIL_Ecommerce.Controllers
{
    public class UserController : Controller
    {

        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }
        // i need 2 actions (one get , one post )

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            var exists = _context.Users.SingleOrDefault(x => x.Email == user.Email);

            if (exists != null)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("Role", user.Role ?? "User");

            //  Redirect based on Role
            if (user.Role == "Admin")
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");


            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _context.Users.Find(userId);

            return View(user);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
