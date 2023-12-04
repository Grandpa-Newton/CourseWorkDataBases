using Lab06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab06.Controllers
{
    [Route("api/[controller]")]
    public class DifficultyController : Controller
    {
        TestingSystemDbContext _db;
        public DifficultyController(TestingSystemDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Получение всех сложностей
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IEnumerable<Difficulty> Get()
        {
            return _db.Difficulties.ToList();
        }

        /// <summary>
        /// Получение сложности по Id
        /// </summary>
        /// <param name="id">Id сложности</param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Difficulty difficulty = _db.Difficulties.FirstOrDefault(t => t.DifficultyId == id);
            if (difficulty == null)
            {
                return NotFound();
            }
            return new ObjectResult(difficulty);
        }

    }
}
