using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data;

namespace ProjectComplete.Controllers
{
    public class CollectionsController : Controller
    {
        public IActionResult Index()
        {
            var data = _context.Collections.ToList();
            return View(data);
        }
        public IActionResult List()
        {
            var data = _context.Collections.ToList();
            return View(data);
        }
    }
}
