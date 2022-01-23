using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data;

namespace ProjectComplete.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        public ItemsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Items.ToList();
            return View(data);
        }
    }
}
