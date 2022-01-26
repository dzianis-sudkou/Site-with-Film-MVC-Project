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
        public CollectionsController(ICollectionsService service, IItemsService itemsService)
        {
            _service = service;
            _itemsService = itemsService;
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewCollectionVM collection, string Id)
        {
            collection.UserId = Id;
            _service.Add(collection);
            return RedirectToAction(nameof(Index));
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
        public IActionResult Edit(int id, Collection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }
            _service.Update(id, collection);
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
            return RedirectToAction(nameof(Index));
        }
    }
}
