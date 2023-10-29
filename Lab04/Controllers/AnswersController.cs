using Lab04.Models;
using Lab04.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab04.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    public class AnswersController : Controller
    {
        private readonly TestingSystemDbContext _db;

        public AnswersController(TestingSystemDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            int numberRows = 10;
            //List<Test> tests = _db.Tests.Include("Difficulty").Include("Topic").Take(numberRows).ToList();
            List<Answer> answers = _db.Answers.Include("Question").Take(numberRows).ToList();
            // List<Question> questions = _db.Questions.Take(numberRows).ToList();
            /* List<AnswersViewModel> answers = _db.Answers.Select(t => new AnswersViewModel
             {
                 AnswerID = t.AnswerId, AnswerText = t.Text, QuestionText = t.Question.Text 
             }).Take(numberRows).ToList();*/

            //return answers.First().Text;
            return PartialView(answers);
            // return View(answers);
        }
    }
}
