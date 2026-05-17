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
        public IActionResult Index()
        {
            return View();
        }
    }
}
