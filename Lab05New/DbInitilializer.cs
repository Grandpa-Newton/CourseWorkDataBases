using Lab05New.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab05New
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

            /* UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

             Random randomObj = new Random(1);

             int usersNumber = 500;
             string login, password, email, name, surname;

             string[] nameVocabulary = { "Иван", "Петр", "Фёдор", "Максим", "Даниил" };
             int userId;

             for (userId = 1; userId <= usersNumber; userId++)
             {
                 login = "Login" + userId.ToString();
                 password = "Password" + userId.ToString() + "_";
                 email = "user" + userId.ToString() + "@gmail.com";
                 name = nameVocabulary[randomObj.Next(nameVocabulary.Length)];
                 surname = nameVocabulary[randomObj.Next(nameVocabulary.Length)] + "ов";
                 ApplicationUser newUser = new ApplicationUser { UserName = login, Email = email, Name = name, Surname = surname };
                 IdentityResult result = await userManager.CreateAsync(newUser, password);

                 if(result.Succeeded)
                 {

                 }

                 // db.Users.Add(new User { Login = login, Password = password, Email = email, Name = name, Surname = surname });
             }*/

            Random randomObj = new Random(1);

            int usersNumber = 501;
            string login, password, email, name, surname;

            string[] nameVocabulary = { "Иван", "Петр", "Фёдор", "Максим", "Даниил" };
            int userId;

            int difficultiesNumber = 3;
            int topicsNumber = 5;


            // Difficulties
            db.Difficulties.Add(new Difficulty { Name = "Лёгкая" });
            db.Difficulties.Add(new Difficulty { Name = "Средняя" });
            db.Difficulties.Add(new Difficulty { Name = "Тяжёлая" });
            db.SaveChanges();

            //Topics
            db.Topics.Add(new Topic { Name = "Игры" });
            db.Topics.Add(new Topic { Name = "Фильмы" });
            db.Topics.Add(new Topic { Name = "Программирование" });
            db.Topics.Add(new Topic { Name = "География" });
            db.Topics.Add(new Topic { Name = "Спорт" });
            db.SaveChanges();

            // Users
            /*  int usersNumber = 500;
              string login, password, email, name, surname;

              string[] nameVocabulary = { "Иван", "Петр", "Фёдор", "Максим", "Даниил" };
              int userId;

              for (userId = 1; userId <= usersNumber; userId++)
              {
                  login = "Login" + userId.ToString();
                  password = "Password" + userId.ToString();
                  email = "user" + userId.ToString() + "@gmail.com";
                  name = nameVocabulary[randomObj.Next(nameVocabulary.Length)];
                  surname = nameVocabulary[randomObj.Next(nameVocabulary.Length)] + "ов";
                  db.Users.Add(new User { Login = login, Password = password, Email = email, Name = name, Surname = surname });
              }
              db.SaveChanges();*/

            // Tests
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            int testsNumber = 80, topicId, difficultyId;
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

            int questionsNumber = 20000;
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
            int resultsNumber = 20000;
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
                    db.CompletionMarks.Add(new CompletionMark { ApplicationUserId = userManager.Users.ToList()[userId].Id, TestId = testId });
                }
            }
            db.SaveChanges();

        }
    }
}
