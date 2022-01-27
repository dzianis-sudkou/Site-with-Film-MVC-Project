using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data.Services;
using ProjectComplete.Models;
using System.Diagnostics;

namespace ProjectComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsService _itemsservice;

        public HomeController(ILogger<HomeController> logger, IItemsService itemsservice)
        {
            _logger = logger;
            _itemsservice = itemsservice;
        }

        public IActionResult Index()
        {
            var data = _itemsservice.GetAll();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}