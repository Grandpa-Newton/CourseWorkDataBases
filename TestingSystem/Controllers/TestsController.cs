using TestingSystem.Models;
using TestingSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestingSystem.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class TestsController : Controller
    {

        private readonly TestingSystemDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        private Test _currentTest;

        public TestsController(TestingSystemDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> IndexByPage(string name, int difficulty = 0, int topic = 0, int page = 1)
        {
            Response.Cookies.Delete("testPage");
            Response.Cookies.Append("testPage", page.ToString());
            return View("Index", GetTestsViewModel(name, difficulty, topic, page).Result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateIndex(string name = "", int difficulty = 0, int topic = 0, int page = 1)
        {
            Response.Cookies.Delete("testName");
            Response.Cookies.Append("testName", name);

            Response.Cookies.Delete("testDifficulty");
            Response.Cookies.Append("testDifficulty", difficulty.ToString());

            Response.Cookies.Delete("testTopic");
            Response.Cookies.Append("testTopic", topic.ToString());

            Response.Cookies.Delete("testPage");
            Response.Cookies.Append("testPage", page.ToString());

            return RedirectToAction("Index") ;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            int difficulty, topic, page;
            if(!Request.Cookies.TryGetValue("testName", out string name))
            {
                name = "";
            }

            if(Request.Cookies.TryGetValue("testDifficulty", out string diff))
            {
                difficulty = Convert.ToInt32(diff);
            }
            else
            {
                difficulty = 0;
            }

            if(Request.Cookies.TryGetValue("testTopic", out string topicString))
            {
                topic = Convert.ToInt32(topicString);
            }
            else
            {
                topic = 0;
            }

            if(Request.Cookies.TryGetValue("testPage", out string pageString))
            {
                page = Convert.ToInt32(pageString);
            }
            else
            {
                page = 1;
            }

            return View(GetTestsViewModel(name, difficulty, topic, page).Result);
        }

        public async Task<TestsViewModel> GetTestsViewModel(string name, int difficulty = 0, int topic = 0, int page = 1)
        {
            int pageSize = 10;

            List<Test> tests = _db.Tests.Include("Difficulty").Include("Topic").ToList();

            if (difficulty != null && difficulty != 0)
            {
                tests = tests.Where(t => t.DifficultyId == difficulty).ToList();
            }
            if (topic != null && topic != 0)
            {
                tests = tests.Where(t => t.TopicId == topic).ToList();
            }

            if (!string.IsNullOrEmpty(name))
            {
                tests = tests.Where(t => t.Name.ToUpperInvariant().Contains(name.ToUpperInvariant())).ToList();
            }

            List<Difficulty> difficulties = _db.Difficulties.ToList();
            difficulties.Insert(0, new Difficulty { Name = "Все", DifficultyId = 0 });
            List<Topic> topics = _db.Topics.ToList();
            topics.Insert(0, new Topic { Name = "Все", TopicId = 0 });

            int count = tests.Count;
            var items = tests.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterTestsViewModel filterTestsViewModel = new FilterTestsViewModel(difficulties, topics, difficulty, topic, name);
            ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            TestsViewModel viewModel = new TestsViewModel(items, pageViewModel, filterTestsViewModel, _db.CompletionMarks, _db.Results, currentUser);

            return viewModel;
        }

        [Authorize]
        public async Task<IActionResult> Take(int id, int questionNumber = 1)
        {

            _currentTest = _db.Tests.Include("Questions").FirstOrDefault(t => t.TestId == id);

            if (_currentTest == null)
            {
                return NotFound();
            }


            TakeTestViewModel viewModel = new TakeTestViewModel
            {
                Test = _currentTest,
                TestId = _currentTest.TestId
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Take(int testId, string[] answers)
        {

            _currentTest = _db.Tests.Include("Questions.Answers").FirstOrDefault(t => t.TestId == testId);


            ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            double result = 0;
            double totalMarks = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                Answer currentAnswer = _currentTest.Questions.ToList()[i].Answers.First();
                totalMarks += _currentTest.Questions.ToList()[i].NumberOfPoints;
                if (answers[i]?.ToUpperInvariant() == currentAnswer.Text.ToUpperInvariant())
                {
                    result += _currentTest.Questions.ToList()[i].NumberOfPoints;
                }
            }

            var currentResult = _db.Results.FirstOrDefault(r => r.TestId == _currentTest.TestId && r.ApplicationUserId == currentUser.Id);

            int mark = Convert.ToInt32(Math.Round((result / totalMarks) * 10));

            if (currentResult == null)
            {
                _db.Results.Add(new Result
                {
                    ApplicationUserId = currentUser.Id,
                    TestId = _currentTest.TestId,
                    Mark = mark

                });
            }
            else
            {
                currentResult.Mark = mark;
            }

            CompletionMark completionMark = _db.CompletionMarks.Where(m => m.TestId == _currentTest.TestId && m.ApplicationUserId == currentUser.Id).FirstOrDefault();

            if (completionMark != null)
            {
                completionMark.Mark = true;
            }
            else
            {
                _db.CompletionMarks.Add(new CompletionMark
                {
                    Mark = true,
                    TestId = _currentTest.TestId,
                    ApplicationUserId = currentUser.Id,
                });
            }

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Create()
        {
            List<Difficulty> difficulties = _db.Difficulties.ToList();

            List<Topic> topics = _db.Topics.ToList();

            CreateTestViewModel viewModel = new CreateTestViewModel(difficulties, topics);

            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestViewModel model)
        {
            bool isValid = false;
            if (ModelState.IsValid)
            {
                isValid = true;
                Test newTest = new Test()
                {
                    Name = model.Name,
                    TopicId = model.TopicId,
                    DifficultyId = model.DifficultyId
                };

                _db.Tests.Add(newTest);
                _db.SaveChanges();

                for (int i = 0; i < model.QuestionNames.Count; i++)
                {
                    Question newQuestion = new Question
                    {
                        Name = model.QuestionNames[i],
                        Text = model.QuestionTexts[i],
                        TestId = newTest.TestId,
                        NumberOfPoints = model.QuestionNumberOfPoints[i]
                    };
                    _db.Questions.Add(newQuestion);
                    _db.SaveChanges();

                    Answer newAnswer = new Answer
                    {
                        Text = model.AnswerTexts[i],
                        QuestionId = newQuestion.QuestionId,
                    };
                    _db.Answers.Add(newAnswer);
                    _db.SaveChanges();

                }

                newTest.NumberOfQuestions = model.QuestionNames.Count;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();

                return ReturnView(model);

            }
        }

        private IActionResult ReturnView(CreateTestViewModel model)
        {
            model.Difficulties = new SelectList(_db.Difficulties.ToList(), "DifficultyId", "Name");
            model.Topics = new SelectList(_db.Topics.ToList(), "TopicId", "Name");

            return View(model);
        }

        private IActionResult ReturnView(EditTestViewModel model)
        {
            model.Difficulties = new SelectList(_db.Difficulties.ToList(), "DifficultyId", "Name");
            model.Topics = new SelectList(_db.Topics.ToList(), "TopicId", "Name");

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            Test test = _db.Tests.Include("Questions.Answers").FirstOrDefault(t => t.TestId == id);

            if (test == null)
            {
                return NotFound();
            }

            List<Difficulty> difficulties = _db.Difficulties.ToList();

            List<Topic> topics = _db.Topics.ToList();

            EditTestViewModel model = new EditTestViewModel(difficulties, topics, test.DifficultyId, test.TopicId);

            model.Id = test.TestId;
            model.Name = test.Name;

            List<string> questionNames = new List<string>();
            List<string> questionTexts = new List<string>();
            List<string> answerTexts = new List<string>();
            List<int> numberOfPoints = new List<int>();


            for (int i = 0; i < test.Questions.Count; i++)
            {
                questionNames.Add(test.Questions.ToList()[i].Name);
                questionTexts.Add(test.Questions.ToList()[i].Text);
                answerTexts.Add(test.Questions.ToList()[i].Answers.First().Text);
                numberOfPoints.Add(test.Questions.ToList()[i].NumberOfPoints);
            }

            model.QuestionNames = questionNames;
            model.QuestionTexts = questionTexts;
            model.AnswerTexts = answerTexts;
            model.QuestionNumberOfPoints = numberOfPoints;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(EditTestViewModel model)
        {
            if (ModelState.IsValid)
            {
                Test test = _db.Tests.Include("Questions.Answers").FirstOrDefault(t => t.TestId == model.Id);

                if (test != null)
                {
                    _db.Questions.RemoveRange(_db.Questions.Where(t => t.TestId == test.TestId));
                    _db.SaveChanges();
                    test.Name = model.Name;
                    test.TopicId = model.SelectedTopicId;
                    test.DifficultyId = model.SelectedDifficultyId;
                    _db.SaveChanges();

                    for (int i = 0; i < model.QuestionNames.Count; i++)
                    {
                        Question newQuestion = new Question
                        {
                            Name = model.QuestionNames[i],
                            Text = model.QuestionTexts[i],
                            TestId = test.TestId,
                            NumberOfPoints = model.QuestionNumberOfPoints[i]
                        };
                        _db.Questions.Add(newQuestion);
                        _db.SaveChanges();
                        Answer newAnswer = new Answer
                        {
                            Text = model.AnswerTexts[i],
                            QuestionId = newQuestion.QuestionId,
                        };
                        _db.Answers.Add(newAnswer);
                    }

                    test.NumberOfQuestions = model.QuestionNames.Count;

                    _db.SaveChanges();


                    return RedirectToAction("Index");

                }
            }
            List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();

            model.Difficulties = new SelectList(_db.Difficulties.ToList(), "DifficultyId", "Name");

            model.Topics = new SelectList(_db.Topics.ToList(), "TopicId", "Name");

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            Test test = _db.Tests.FirstOrDefault(t => t.TestId == id);

            if (test != null)
            {
                _db.Tests.Remove(test);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
