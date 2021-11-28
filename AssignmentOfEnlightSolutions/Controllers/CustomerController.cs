using AssignmentOfEnlightSolutions_DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentOfEnlightSolutions.Controllers
{
    
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
