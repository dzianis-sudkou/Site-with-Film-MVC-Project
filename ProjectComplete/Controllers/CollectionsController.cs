using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data;
using ProjectComplete.Data.Services;
using ProjectComplete.Data.ViewModels;
using ProjectComplete.Models;

namespace ProjectComplete.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly ICollectionsService _service;
        private readonly IItemsService _itemsService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CollectionsController(ICollectionsService service, IItemsService itemsService, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _itemsService = itemsService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        public IActionResult List()
        {
            var data = _service.GetAll();
            return View(data);
        }

        //Get: Collections/Create

        public IActionResult Create(string id)
        {
            ViewBag.Id = id; 
            return View();
        }
        [HttpPost]
        public IActionResult Create(string id, NewCollectionVM collection)
        {
            collection.UserId = id;
            _service.Add(collection);
            return RedirectToAction("Index", "Account");
        }

        //Get: Collections/Details/1
        public IActionResult Details (int id)
        {
            ViewBag.Collection = _service.GetById(id);
            var Details = _itemsService.GetAllById(id);
            if (Details == null) return View("NotFound");
            return View(Details);
        }

        //Get: Collections/Edit/1


        public IActionResult Edit(int id)
        {
            var collectionDetails = _service.GetById(id);
            if (collectionDetails == null) return View("NotFound");
            return View(collectionDetails);
        }
        [HttpPost]
        public IActionResult Edit(Collection collection)
        {
            _service.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        //Get: Collections/Delete/1

        public IActionResult Delete(int id)
        {
            var collectionDetails = _service.GetById(id);
            if (collectionDetails == null) return View("NotFound");
            return View(collectionDetails);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmation(int id)
        {
            var collectionDetails = _service.GetById(id);
            if (collectionDetails == null) return View("NotFound");
            _service.Delete(id);
            return RedirectToAction("Index", "Account");
        }
    }
}
