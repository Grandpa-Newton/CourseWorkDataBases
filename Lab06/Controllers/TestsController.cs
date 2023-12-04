using Lab06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Lab06.Controllers
{
    [Route("api/[controller]")]
    public class TestsController : Controller
    {
        TestingSystemDbContext _db;
        public TestsController(TestingSystemDbContext context)
        {
            _db = context;
            if(!_db.Tests.Any())
            {
                if(!_db.Difficulties.Any())
                {
                    _db.Difficulties.Add(new Difficulty { Name = "Лёгкая" });
                    _db.Difficulties.Add(new Difficulty { Name = "Средняя" });
                    _db.Difficulties.Add(new Difficulty { Name = "Тяжёлая" });
                    _db.SaveChanges();
                }
                if(!_db.Topics.Any())
                {
                    _db.Topics.Add(new Topic { Name = "Фильмы" });
                    _db.Topics.Add(new Topic { Name = "Программирование" });
                    _db.Topics.Add(new Topic { Name = "Игры" });
                    _db.SaveChanges();
                }

                _db.Tests.Add(new Test { Name = "Test1", DifficultyId = 1, TopicId = 2, NumberOfQuestions = 8 });
                _db.Tests.Add(new Test { Name = "Test2", DifficultyId = 3, TopicId = 1, NumberOfQuestions = 5 });
                _db.Tests.Add(new Test { Name = "Test3", DifficultyId = 2, TopicId = 3, NumberOfQuestions = 12 });
                _db.SaveChanges();

            }
        }

        /// <summary>
        /// Получение всех тестов
        /// </summary>
        /// <returns>Список тестов</returns>

        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return _db.Tests.Include("Topic").Include("Difficulty").ToList();
        }

        /// <summary>
        /// Получение теста по Id
        /// </summary>
        /// <param name="id">Id теста</param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Test test = _db.Tests.Include("Topic").Include("Difficulty").FirstOrDefault(t => t.TestId == id);
            if(test == null)
            {
                return NotFound();
            }
            return new ObjectResult(test);
        }

        /// <summary>
        /// Добавление нового теста
        /// </summary>
        /// <param name="test">Тест для добавления</param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post([FromBody] Test test)
        {
            List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _db.Tests.Add(test);
            _db.SaveChanges();
            test.Difficulty = _db.Difficulties.FirstOrDefault(d => d.DifficultyId == test.DifficultyId);
            test.Topic = _db.Topics.FirstOrDefault(d => d.TopicId == test.TopicId);
            return Ok(test);
        }

        /// <summary>
        /// Обновление теста
        /// </summary>
        /// <param name="test">Тест для обновления</param>
        /// <returns></returns>

        [HttpPut]
        public IActionResult Put([FromBody] Test test)
        {
            if(!_db.Tests.Any(t => t.TestId == test.TestId))
            {
                ModelState.AddModelError("", "Тест с таким Id не назван");
                return NotFound(ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Update(test);
            _db.SaveChanges();

            test.Difficulty = _db.Difficulties.FirstOrDefault(d => d.DifficultyId == test.DifficultyId);
            test.Topic = _db.Topics.FirstOrDefault(d => d.TopicId == test.TopicId);
            return Ok(test);
        }

        /// <summary>
        /// Удаление теста по Id
        /// </summary>
        /// <param name="id">Id теста для удаления</param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Test test = _db.Tests.FirstOrDefault(t => t.TestId == id);
            if(test == null)
            {
                return NotFound();
            }
            _db.Tests.Remove(test);
            _db.SaveChanges();
            return Ok(test);
        }


    }
}
