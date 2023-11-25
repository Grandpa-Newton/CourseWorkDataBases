using Lab05New.Models;
using Lab05New.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Lab05New.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class TopicsController : Controller
    {
        private readonly TestingSystemDbContext _db;
        private readonly IMemoryCache _cache;

        public TopicsController(TestingSystemDbContext db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIndex(string name="", int page=1)
        {
            Response.Cookies.Delete("topicName");
            Response.Cookies.Append("topicName", name);

            Response.Cookies.Delete("topicPage");
            Response.Cookies.Append("topicPage", page.ToString());

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Index()
        {
            // int numberRows = 10;

            //List<Topic> topics = _db.Topics.Take(numberRows).ToList();

            int pageSize = 10;

            _cache.TryGetValue("topics", out List<Topic> topics);

            if(topics == null)
            {
                topics = _db.Topics.ToList();

                if(topics != null)
                {
                    _cache.Set("topics", topics, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }

                Console.WriteLine("Данные были взяти из памяти.");
            }
            else
            {
                Console.WriteLine("Данные были взяти их кэша.");
            }

            string name;
            int page;

            if(!Request.Cookies.TryGetValue("topicName", out name))
            {
                name = "";
            }

            if(Request.Cookies.TryGetValue("topicPage", out string pageString))
            {
                page = Convert.ToInt32(pageString);
            }
            else
            {
                page = 1;
            }

            if(!string.IsNullOrEmpty(name))
            {
                topics = topics.Where(t => t.Name.ToUpperInvariant().Contains(name.ToUpperInvariant())).ToList();
            }

            int count = topics.Count;
            var items = topics.Skip((page-1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterTopicsViewModel filterTopicsViewModel = new FilterTopicsViewModel(name);
            TopicsViewModel model = new TopicsViewModel(items, pageViewModel, filterTopicsViewModel);

         //   List<Topic> topics = _db.Topics.ToList();

            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            CreateTopicViewModel viewModel = new CreateTopicViewModel();

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateTopicViewModel model)
        {
            if(ModelState.IsValid)
            {
                Topic newTopic = new Topic()
                {
                    Name = model.Name
                };

                _db.Topics.Add(newTopic);
                _db.SaveChanges();

                _cache.Remove("topics");

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles ="admin")]
        public IActionResult Edit(int id)
        {
            Topic topic = _db.Topics.FirstOrDefault(t => t.TopicId == id);

            if(topic == null)
            {
                return NotFound();
            }

            EditTopicViewModel model = new EditTopicViewModel()
            {
                Id = topic.TopicId,
                Name = topic.Name
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        public IActionResult Edit(EditTopicViewModel model)
        {
            if(ModelState.IsValid)
            {
                Topic topic = _db.Topics.FirstOrDefault(t => t.TopicId == model.Id);

                if (topic != null)
                {
                    topic.Name = model.Name;
                    _db.SaveChanges();

                    _cache.Remove("topics");

                    return RedirectToAction("Index");
                }
            }


            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            Topic topic = _db.Topics.FirstOrDefault(t =>t.TopicId == id);

            if(topic != null)
            {
                _db.Topics.Remove(topic);
                _db.SaveChanges();
                _cache.Remove("topics");
            }

            return RedirectToAction("Index");
        }
    }
}
