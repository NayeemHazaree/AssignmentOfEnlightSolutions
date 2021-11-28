using AssignmentOfEnlightSolutions_DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentOfEnlightSolutions.Controllers
{
    public class CustomerItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SelectListItem> ItemDropDown = _db.Item.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.ItemDropDown = ItemDropDown;
            return View();
        }

        public IActionResult GetPrice(Guid id)
        {
            var item = _db.Item.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Json(new {price=item.Price});
        }


    }
}
