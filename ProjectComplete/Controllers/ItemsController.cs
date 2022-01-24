using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data;
using ProjectComplete.Data.Services;
using ProjectComplete.Models;

namespace ProjectComplete.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;
        public ItemsController(IItemsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        public IActionResult Create(int id)
        {
            return View();
        }

    }
}
