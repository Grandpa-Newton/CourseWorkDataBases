using TestingSystem.Models;
using TestingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace TestingSystem.Controllers
{
    [ResponseCache(CacheProfileName = "Caching")]
    [Authorize(Roles ="admin")]
    public class ResultsController : Controller
    {

        private readonly TestingSystemDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ResultsController(TestingSystemDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIndex(string user = "", int test=0, int page=1)
        {
            Response.Cookies.Delete("resultUser");
            Response.Cookies.Append("resultUser", user);

            Response.Cookies.Delete("resultTest");
            Response.Cookies.Append("resultTest", test.ToString());

            Response.Cookies.Delete("resultPage");
            Response.Cookies.Append("resultPage", page.ToString());

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            string user;
            int test, page;

            if(!Request.Cookies.TryGetValue("resultUser", out user))
            {
                user = "";
            }
            if(Request.Cookies.TryGetValue("resultTest", out string tst))
            {
                test = Convert.ToInt32(tst);
            }
            else
            {
                test = 0;
            }

            if(Request.Cookies.TryGetValue("resultPage", out string pageString))
            {
                page = Convert.ToInt32(pageString);
            }
            else
            {
                page = 1;
            }

            int pageSize = 10;

            List<Result> results = _db.Results.Include("Test").Include("ApplicationUser").ToList();

            if (!string.IsNullOrEmpty(user))
            {
                results = results.Where(r => r.ApplicationUserId == user).ToList();
            }
            if (test != 0 && test != null)
            {
                results = results.Where(r => r.TestId == test).ToList();
            }

            List<ApplicationUser> users = _userManager.Users.ToList();
            users.Insert(0, new ApplicationUser { UserName = "Все", Id = "" });
            List<Test> tests = _db.Tests.ToList();
            tests.Insert(0, new Test { Name = "Все", TestId = 0 });


            int count = results.Count;

            var items = results.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            FilterResultsViewModel filterResultsViewModel = new FilterResultsViewModel(users, tests, user, test);
            ResultsViewModel viewModel = new ResultsViewModel(pageViewModel, filterResultsViewModel, users, items);

            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            Result result = _db.Results.Include("Test").Include("ApplicationUser").FirstOrDefault(r => r.ResultId == id);

            if (result == null)
            {
                return NotFound();
            }

            EditResultViewModel model = new EditResultViewModel()
            {
                Mark = result.Mark,
                Id = result.ResultId,
                TestName = result.Test.Name,
                UserName = result.ApplicationUser.UserName
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(EditResultViewModel model)
        {
            if(ModelState.IsValid)
            {
                Result result = _db.Results.Include("Test").Include("ApplicationUser").FirstOrDefault(r => r.ResultId == model.Id);

                if(result != null)
                {
                    result.Mark = model.Mark;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            Result result = _db.Results.FirstOrDefault(r => r.ResultId == id);

            if (result != null)
            {
                CompletionMark mark = _db.CompletionMarks.FirstOrDefault(m => m.TestId == result.TestId && m.ApplicationUserId == result.ApplicationUserId);
                mark.Mark = false;
                _db.Results.Remove(result);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
