using AssignmentOfEnlightSolutions_DataAccess.Data;
using AssignmentOfEnlightSolutions_Models;
using AssignmentOfEnlightSolutions_Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentOfEnlightSolutions.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(Guid? id)
        {
            IEnumerable<Item> itemList = _db.Item;
            return View(itemList);
        }
        
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Item.Add(item);
                TempData[WC.Success] = "Item Created Successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);

        }

        //GET - EDIT
        public IActionResult Edit(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.Item.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Item.Update(item);
                TempData[WC.Success] = "Item Edited Successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);

        }

        //GET - DELETE
        public IActionResult Delete(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var obj = _db.Item.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid? id)
        {
            var obj = _db.Item.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData[WC.Error] = "Item Deleted";
            _db.Item.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
