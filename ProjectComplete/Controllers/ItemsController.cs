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
            return View(data);
        }

        //Get Items/Edit/1
        public IActionResult Edit(int id)
        {
            var data = _itemsService.GetItemById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            _itemsService.Update(id, item);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Comment(int id, string comment)
        {
            string userid = _userManager.GetUserId(User);
            _commentService.AddAsync(userid, id, comment);
            return View(nameof(Details));
        }
    }
}
