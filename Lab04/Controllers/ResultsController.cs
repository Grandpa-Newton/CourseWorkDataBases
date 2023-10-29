using Lab04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class ResultsController : Controller
    {

        private readonly TestingSystemDbContext _db;

        public ResultsController(TestingSystemDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;

            List<Result> results = _db.Results.Include("Test").Include("User").Take(numberRows).ToList();

            return PartialView(results);
        }
    }
}
