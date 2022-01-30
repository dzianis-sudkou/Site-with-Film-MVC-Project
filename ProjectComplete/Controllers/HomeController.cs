using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data.Services;
using ProjectComplete.Models;
using System.Diagnostics;

namespace ProjectComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemsService _itemsservice;

        public HomeController(IItemsService itemsservice)
        {
            _itemsservice = itemsservice;
        }

        public IActionResult Index()
        {
            var data = _itemsservice.GetAll();
            return View(data);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
        public IActionResult Test()
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