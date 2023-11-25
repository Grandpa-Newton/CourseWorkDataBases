using Lab05New.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab05New.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class CompletionMarksController : Controller
    {
        private readonly TestingSystemDbContext _db;

        public CompletionMarksController(TestingSystemDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;
            
            List<CompletionMark> marks = _db.CompletionMarks.Include("Test").Include("User").Take(numberRows).ToList();

            return PartialView(marks);
            // return View(answers);
        }
    }
}
