using Lab06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab06.Controllers
{
    [Route("api/[controller]")]
    public class TopicsController : Controller
    {
        TestingSystemDbContext _db;
        public TopicsController(TestingSystemDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Получение списка тематик
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IEnumerable<Topic> Get()
        {
            return _db.Topics.ToList();
        }

        /// <summary>
        /// Получение тематики по Id
        /// </summary>
        /// <param name="id">Id тематики</param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Topic topic = _db.Topics.FirstOrDefault(t => t.TopicId == id);
            if (topic == null)
            {
                return NotFound();
            }
            return new ObjectResult(topic);
        }
    }
}
