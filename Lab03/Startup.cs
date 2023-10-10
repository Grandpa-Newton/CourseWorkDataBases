using Lab03.Models;
using Lab03.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Linq;
using System.Text;

namespace Lab03
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=MSI;Database=TestingSystemDb;Trusted_Connection=True;";
            services.AddDbContext<TestingSystemDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<CachedAnswersService>();

            services.AddTransient<CachedCompletionMarksService>();

            services.AddTransient<CachedDifficultiesService>();

            services.AddTransient<CachedQuestionsService>();

            services.AddTransient<CachedResultsService>();

            services.AddTransient<CachedTestsService>();

            services.AddTransient<CachedTopicsService>();

            services.AddTransient<CachedUsersService>();


            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddMemoryCache();

            // services.AddControllersWithViews();
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/info", Info);
            app.Map("/answers", Answers);
            app.Map("/completionMarks", CompletionMarks);
            app.Map("/difficulties", Difficulties);
            app.Map("/questions", Questions);
            app.Map("/results", Results);
            app.Map("/tests", Tests);
            app.Map("/topics", Topics);
            app.Map("/users", Users);
            app.Map("/searchform1", FirstForm);
            app.Map("/getResultsForm1", GetResultsForm1);
            app.UseSession();
            app.Map("/searchform2", SecondForm);
            app.Map("/getResultsForm2", GetResultsForm2);



            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private static void GetResultsForm2(IApplicationBuilder app)
        {
            app.Run((context) =>
            {

                var form = context.Request.Form;
                context.Session.SetInt32("numberOfQuestions", Convert.ToInt32(form["numberOfQuestions"]));
                context.Session.SetInt32("topicId", Convert.ToInt32(form["topics"]));
                
                CachedTestsService testService = context.RequestServices.GetService<CachedTestsService>();
                List<Test> tests = testService.GetTests().Where(test => test.NumberOfQuestions > context.Session.GetInt32("numberOfQuestions") && test.TopicId == context.Session.GetInt32("topicId")).Take(20).ToList();//.Where(t => t.NumberOfQuestions > Convert.ToInt32(form["numberOfQuestions"]) && t.TopicId == form["topics"]).ToList();
                if (tests != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (var test in tests)
                    {
                        stringBuilder.Append($"Test {test.Name} Id = {test.TestId}  TopicId = {test.TopicId}  DifficultyId = {test.DifficultyId}   NumberOfQuestions = {test.NumberOfQuestions}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Tests not found");


            });
        }

        private static void SecondForm(IApplicationBuilder app)
        {

            app.Run((context) =>
            {

                CachedTopicsService topicsService = context.RequestServices.GetService<CachedTopicsService>();
                List<Topic> topics = topicsService.GetTopics().ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append("<html><meta charset=\"UTF-8\"><body>Searching in Tests");
                if (context.Session.Keys.Contains("numberOfQuestions") && context.Session.Keys.Contains("topicId"))
                {
                    int? numberOfQuestions = context.Session.GetInt32("numberOfQuestions");
                    sb.Append("<br><form method=\"post\" action = \"getResultsForm2\" > Min Number Of Questions:<br><input type = 'number' name = 'numberOfQuestions' value = " + numberOfQuestions + ">");
                    sb.Append("<br>Тематика<br>");
                    sb.Append("<select name='topics'>");
                    foreach (var item in topics)
                    {
                        if (item.TopicId == context.Session.GetInt32("topicId"))
                        {
                            sb.Append($"<option value={item.TopicId} selected>{item.Name}</option>");
                        }
                        else
                        {
                            sb.Append($"<option value={item.TopicId}>{item.Name}</option>");
                        }
                    }

                    sb.Append("</select><br><input type = 'submit' value = 'Submit' ></form></body></html>");
                }
                else
                {
                    sb.Append("<br><form method=\"post\" action = \"getResultsForm2\" > Min Number Of Questions:<br><input type = 'number' name = 'numberOfQuestions'" + ">");
                    sb.Append("<br>Тематика<br>");
                    sb.Append("<select name='topics'>");
                    foreach (var item in topics)
                    {
                        sb.Append($"<option value={item.TopicId}>{item.Name}</option>");
                    }
                    sb.Append("</select><br><input type = 'submit' value = 'Submit' ></form></body></html>");
                }

                return context.Response.WriteAsync(sb.ToString());

                /* string firstname = "";
                 string strresponse = "<html><body><form action = / >" +
                 "First name:<br><input type = 'text' name = 'firstname' value = " + "A" + ">" +
                 "<br>Last name:<br><input type = 'text' name = 'lastname' value = 'Mouse' >" +
                 "<br><br><input type = 'submit' value = 'Submit' ></form></body></html>";

                 return context.Response.WriteAsync(strresponse);*/



            });
        }

        private static void GetResultsForm1(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                var form = context.Request.Form;
                context.Response.Cookies.Append("minTestId", form["testID"]);
                context.Response.Cookies.Append("difficultyId", form["difficulties"]);


                CachedTestsService testService = context.RequestServices.GetService<CachedTestsService>();
                List<Test> tests = testService.GetTests().Where(t => t.TestId > Convert.ToInt32(form["testID"]) && t.DifficultyId == Convert.ToInt32(form["difficulties"])).Take(20).ToList();
                if (tests != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (var test in tests)
                    {
                        stringBuilder.Append($"Test {test.Name} Id = {test.TestId}  TopicId = {test.TopicId}  DifficultyId = {test.DifficultyId}   NumberOfQuestions = {test.NumberOfQuestions}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Tests not found");
            });
        }

        private static void FirstForm(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<html><meta charset=\"UTF-8\"><body>Searching in Tests");

                CachedDifficultiesService difficultiesService = context.RequestServices.GetService<CachedDifficultiesService>();
                List<Difficulty> difficulties = difficultiesService.GetDifficulties().ToList();
                if (context.Request.Cookies.ContainsKey("minTestId") && context.Request.Cookies.ContainsKey("difficultyId"))
                {
                    int minTestId = Convert.ToInt32(context.Request.Cookies["minTestId"]);
                    sb.Append("<br><form method=\"post\" action = \"getResultsForm1\" > Min TestID:<br><input type = 'number' name = 'testID' value = " + minTestId + ">");

                    sb.Append("<br>Сложность<br>");
                    sb.Append("<select name='difficulties'>");
                    foreach (var item in difficulties)
                    {
                        if (item.DifficultyId == Convert.ToInt32(context.Request.Cookies["difficultyId"]))
                        {
                            sb.Append($"<option value={item.DifficultyId} selected>{item.Name}</option>");
                        }
                        else
                        {
                            sb.Append($"<option value={item.DifficultyId}>{item.Name}</option>");
                        }
                    }
                 
                    sb.Append("</select><br><input type = 'submit' value = 'Submit' ></form></body></html>");
                }
                else
                {
                    sb.Append("<br><form method=\"post\" action = \"getResultsForm1\" > Min TestID:<br><input type = 'number' name = 'testID'" + ">");

                    sb.Append("<br>Сложность<br>");
                    sb.Append("<select name='difficulties'>");
                    foreach (var item in difficulties)
                    {
                        sb.Append($"<option value={item.DifficultyId}>{item.Name}</option>");
                    }
                    sb.Append("</select><br><input type = 'submit' value = 'Submit' ></form></body></html>");
                }

                return context.Response.WriteAsync(sb.ToString());

                /* string firstname = "";
                 string strresponse = "<html><body><form action = / >" +
                 "First name:<br><input type = 'text' name = 'firstname' value = " + "A" + ">" +
                 "<br>Last name:<br><input type = 'text' name = 'lastname' value = 'Mouse' >" +
                 "<br><br><input type = 'submit' value = 'Submit' ></form></body></html>";

                 return context.Response.WriteAsync(strresponse);*/



            });
        }

        private static void Users(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                CachedUsersService userService = context.RequestServices.GetService<CachedUsersService>();
                List<User> users = userService.GetUsers().ToList();
                if (users != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var user in users)
                    {
                        stringBuilder.Append($"User {user.Login} Id = {user.UserId}  Password = {user.Password}  Name = {user.Name}   Surname = {user.Surname}" +
                            $"  Email = {user.Email}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Users not found");
            });
        }

        private static void Topics(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                context.Response.ContentType = "text/plain;charset=utf-8";
                CachedTopicsService topicService = context.RequestServices.GetService<CachedTopicsService>();
                List<Topic> topics = topicService.GetTopics().ToList();
                if (topics != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var topic in topics)
                    {
                        stringBuilder.Append($"Topic {topic.Name} Id = {topic.TopicId}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Topics not found");
            });
        }
        private static void Tests(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                CachedTestsService testService = context.RequestServices.GetService<CachedTestsService>();
                List<Test> tests = testService.GetTests("Test20").ToList();
                if (tests != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var test in tests)
                    {
                        stringBuilder.Append($"Test {test.Name} Id = {test.TestId}  TopicId = {test.TopicId}  DifficultyId = {test.DifficultyId}   NumberOfQuestions = {test.NumberOfQuestions}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Tests not found");
            });
        }

        private static void Results(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                CachedResultsService resultService = context.RequestServices.GetService<CachedResultsService>();
                List<Result> results = resultService.GetResults("Results20").ToList();
                if (results != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var result in results)
                    {
                        stringBuilder.Append($"TestId = {result.TestId}   UserId = {result.UserId}  Mark = {result.Mark}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Results not found");
            });
        }

        private static void Questions(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                CachedQuestionsService questionService = context.RequestServices.GetService<CachedQuestionsService>();
                List<Question> questions = questionService.GetQuestions().ToList();
                if (questions != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var question in questions)
                    {
                        stringBuilder.Append($"Question {question.Name} Id = {question.QuestionId}  Text = {question.Text}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Questions not found");
            });
        }

        private static void Info(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("UserName: " + Environment.UserName);
                stringBuilder.AppendLine("OS Version: " + Environment.OSVersion);
                stringBuilder.AppendLine("ProcessorCount: " + Environment.ProcessorCount);
                return context.Response.WriteAsync(stringBuilder.ToString());
            });
        }

        private static void Answers(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                CachedAnswersService answerService = context.RequestServices.GetService<CachedAnswersService>();
                List<Answer> answers = answerService.GetAnswers().ToList();
                if (answers != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var answer in answers)
                    {
                        stringBuilder.Append($"Answer {answer.Text} Id = {answer.AnswerId}  QuestionId = {answer.QuestionId}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Answers not found");
            });
        }

        private static void CompletionMarks(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                CachedCompletionMarksService completionMarksService = context.RequestServices.GetService<CachedCompletionMarksService>();
                List<CompletionMark> completionMarks = completionMarksService.GetCompletionMarks().ToList();
                if (completionMarks != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var completionMark in completionMarks)
                    {
                        stringBuilder.Append($"Completion Mark Id {completionMark.CompletionMarkId} UserId = {completionMark.UserId}  Mark = {completionMark.Mark}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Answers not found");
            });
        }

        private static void Difficulties(IApplicationBuilder app)
        {
            app.Run((context) =>
            {
                context.Response.ContentType = "text/plain;charset=utf-8";
                CachedDifficultiesService difficultiesService = context.RequestServices.GetService<CachedDifficultiesService>();
                List<Difficulty> difficulties = difficultiesService.GetDifficulties().ToList();
                if (difficulties != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var difficulty in difficulties)
                    {
                        stringBuilder.Append($"Difficulty {difficulty.Name} Id = {difficulty.DifficultyId}" + Environment.NewLine);
                    }
                    return context.Response.WriteAsync(stringBuilder.ToString());
                }
                return context.Response.WriteAsync("Difficulties not found");
            });
        }
    }
}
