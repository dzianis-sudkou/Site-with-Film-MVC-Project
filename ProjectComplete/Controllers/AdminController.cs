using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data.Services;

namespace ProjectComplete.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var data = _adminService.ToList();
            return View(data);
        }
        public async Task<IActionResult> newAdminAsync(string id)
        {
            await _adminService.newAdminAsync(id);
            return RedirectToAction(nameof(Users));
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _adminService.Delete(id);
            return RedirectToAction(nameof(Users));
        }

    }
}
