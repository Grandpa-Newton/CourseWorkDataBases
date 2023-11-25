using Lab05New.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab05New.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class DifficultiesController : Controller
    {
        private readonly TestingSystemDbContext _db;

        public DifficultiesController(TestingSystemDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;

            List<Difficulty> difficulties = _db.Difficulties.Take(numberRows).ToList();

            return PartialView(difficulties);
            // return View(answers);
        }
    }
}
