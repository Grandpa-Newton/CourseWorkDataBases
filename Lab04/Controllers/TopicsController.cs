using Lab04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class TopicsController : Controller
    {
        private readonly TestingSystemDbContext _db;

        public TopicsController(TestingSystemDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;

            List<Topic> topics = _db.Topics.Take(numberRows).ToList();

            return PartialView(topics);
        }
    }
}
