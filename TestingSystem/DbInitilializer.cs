using TestingSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace TestingSystem
{
    public class DbInitilializer
    {
        public static async Task Initialize(TestingSystemDbContext db, IServiceProvider serviceProvider)
        {
            db.Database.EnsureCreated();

            if(db.Difficulties.Any())
            {
                return;
            }

            Random randomObj = new Random(1);

            int usersNumber = 501;
            string login, password, email, name, surname;

            string[] nameVocabulary = { "Иван", "Петр", "Фёдор", "Максим", "Даниил" };
            int userId;

            int topicId, difficultyId;

            int difficultiesNumber = 100;
            int topicsNumber = 100;

            // Difficulties
            db.Difficulties.Add(new Difficulty { Name = "Лёгкая" });
            db.Difficulties.Add(new Difficulty { Name = "Средняя" });
            db.Difficulties.Add(new Difficulty { Name = "Тяжёлая" });

            for (difficultyId = 4; difficultyId <= difficultiesNumber; difficultyId++)
            {
                db.Difficulties.Add(new Difficulty { Name = "Difficulty" + difficultyId });
            }

            db.SaveChanges();

            //Topics
            db.Topics.Add(new Topic { Name = "Игры" });
            db.Topics.Add(new Topic { Name = "Фильмы" });
            db.Topics.Add(new Topic { Name = "Программирование" });
            db.Topics.Add(new Topic { Name = "География" });
            db.Topics.Add(new Topic { Name = "Спорт" });

            for (topicId = 6; topicId <= topicsNumber; topicId++)
            {
                db.Topics.Add(new Topic { Name = "Topic" + topicId });
            }

            db.SaveChanges();

            // Tests
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            int testsNumber = 100;
            int testId;

            for (testId = 1; testId <= testsNumber; testId++)
            {
                name = "Test" + testId.ToString();
                topicId = randomObj.Next(1, topicsNumber + 1);
                difficultyId = randomObj.Next(1, difficultiesNumber + 1);
                db.Tests.Add(new Test {  Name = name, TopicId = topicId, DifficultyId = difficultyId });
            }
            db.SaveChanges();

            // Questions

            int questionsNumber = 10000;
            int numberOfPoints;
            string text;
            int questionId;

            for (questionId = 1; questionId <= questionsNumber; questionId++)
            {
                name = "Question" + questionId.ToString();
                text = "Question_Text" + questionId.ToString() + "?";
                testId = randomObj.Next(1, testsNumber + 1);
                numberOfPoints = randomObj.Next(1, 6);
                db.Questions.Add(new Question { Name = name, Text = text, TestId = testId, NumberOfPoints = numberOfPoints });
            }
            db.SaveChanges();

            // Answers
            int answersNumber = questionsNumber;


            for (int answerId = 1; answerId <= answersNumber; answerId++)
            {
                text = "Answer" + answerId.ToString();
                questionId = answerId;
                db.Answers.Add(new Answer {  Text = text, QuestionId = questionId });
            }
            db.SaveChanges();

            // Results
            int resultsNumber = 10000;
            int mark;

            for (int resultId = 1; resultId <= resultsNumber; resultId++)
            {
                mark = randomObj.Next(1, 11);
                testId = randomObj.Next(1, testsNumber + 1);
                userId = randomObj.Next(0, usersNumber);
                db.Results.Add(new Result { Mark = mark, TestId = testId, ApplicationUserId = userManager.Users.ToList()[userId].Id });
            }
            db.SaveChanges();

            // Completion Marks

            for (userId = 0; userId < usersNumber; userId++)
            {
                for (testId = 1; testId <= testsNumber; testId++)
                {
                    var user = userManager.Users.ToList()[userId];
                    if (db.Results.FirstOrDefault(r => r.ApplicationUserId == user.Id && r.TestId == testId) != null)
                    {
                        db.CompletionMarks.Add(new CompletionMark { ApplicationUserId = userManager.Users.ToList()[userId].Id, TestId = testId, Mark = true });
                    }
                    else
                    {
                        db.CompletionMarks.Add(new CompletionMark { ApplicationUserId = userManager.Users.ToList()[userId].Id, TestId = testId, Mark = false });
                    }
                }
            }
            db.SaveChanges();

            for (testId = 1; testId <= testsNumber; testId++)
            {
                Test test = db.Tests.First(t => t.TestId == testId);
                test.NumberOfQuestions = db.Questions.Where(q => q.TestId == testId).Count();
            }
            db.SaveChanges();
        }
    }
}
