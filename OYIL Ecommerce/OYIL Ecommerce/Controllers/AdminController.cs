using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OYIL_Ecommerce.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Admin")
            {
                return Unauthorized();
            }

            return View();
        }
    }
}
