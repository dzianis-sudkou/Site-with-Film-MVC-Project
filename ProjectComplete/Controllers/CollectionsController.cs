using Microsoft.AspNetCore.Mvc;
using ProjectComplete.Data;
using ProjectComplete.Data.Services;
using ProjectComplete.Models;

namespace ProjectComplete.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly ICollectionsService _service;
        public CollectionsController(ICollectionsService service)
        {
            _service = service;
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
        public IActionResult Create(Collection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }
            _service.Add(collection);
            return RedirectToAction(nameof(Index));
        }

        //Get: Collectios/Details/1
        public IActionResult Details (int id)
        {
            var actorDetails = _service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
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
