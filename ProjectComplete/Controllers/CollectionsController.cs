using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data;

namespace ProjectComplete.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly AppDbContext _context;
        public CollectionsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Collections.ToList();
            return View(data);
        }
    }
}
