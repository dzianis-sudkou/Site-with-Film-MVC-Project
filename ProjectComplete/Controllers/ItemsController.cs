using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data;
using ProjectComplete.Data.Services;
using ProjectComplete.Data.ViewModels;
using ProjectComplete.Models;

namespace ProjectComplete.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _itemsService;
        private readonly ICollectionsService _collectionsService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICommentService _commentService;
        public ItemsController(IItemsService itemsService, ICollectionsService collectionsService, UserManager<ApplicationUser> userManager, ICommentService commentService )
        {
            _itemsService = itemsService;
            _collectionsService = collectionsService;
            _userManager = userManager;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            var data = _itemsService.GetAll();
            return View(data);
        }

        public IActionResult Filter(string searchString)
        {
            var data = _itemsService.Filter(searchString);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewItemsVM item)
        {
            _itemsService.AddAsync(item);
            return RedirectToAction(nameof(Index));
        }
        //Get Items/Details/1
        public IActionResult Details(int id)
        {
            var data = _itemsService.GetItemById(id);
            ViewBag.Comments = _commentService.GetAll(id);
            return View(data);
        }

        //Get Items/Edit/1
        public IActionResult Edit(int id)
        {
            var data = _itemsService.GetItemById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            _itemsService.Update(item);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CommentAsync(int id, string comment)
        {
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
            await _commentService.AddAsync(user, id, comment);
            return Redirect($"../Items/Details/{id}");
        }
        public IActionResult Delete(int id)
        {
            var item = _itemsService.GetItemById(id);
            if (item == null) return View("NotFound");
            return View(item);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmation(int id)
        {
            var item = _itemsService.GetItemById(id);
            if (item == null) return View("NotFound");
            _itemsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
