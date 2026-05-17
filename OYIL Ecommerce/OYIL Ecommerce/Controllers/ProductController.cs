using Microsoft.AspNetCore.Mvc;
using OYIL_Ecommerce.Models;

namespace OYIL_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
      

        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
