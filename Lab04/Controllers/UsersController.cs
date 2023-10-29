using Lab04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class UsersController : Controller
    {
        private readonly TestingSystemDbContext _db;

        public UsersController(TestingSystemDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;

           // List<Topic> topics = _db.Topics.Take(numberRows).ToList();

            List<User> users = _db.Users.Take(numberRows).ToList();

            return PartialView(users);
        }
    }
}
