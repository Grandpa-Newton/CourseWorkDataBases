using Lab04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class QuestionsController : Controller
    {

        private readonly TestingSystemDbContext _db;

        public QuestionsController(TestingSystemDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;

            List<Question> questions = _db.Questions.Include("Test").Take(numberRows).ToList();

            return PartialView(questions);
        }
    }
}
