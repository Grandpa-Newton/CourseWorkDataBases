using Lab04.Models;

namespace Lab04
{
    public class DbInitilializer
    {
        public static void Initialize(TestingSystemDbContext db)
        {
            db.Database.EnsureCreated();

            if(db.Difficulties.Any())
            {
                return;
            }

            int difficultiesNumber = 3;
            int topicsNumber = 5;
            Random randomObj = new Random(1);


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
            int usersNumber = 500;
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
            db.SaveChanges();

            // Tests
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
                userId = randomObj.Next(1, usersNumber + 1);
                db.Results.Add(new Result { Mark = mark, TestId = testId, UserId = userId });
            }
            db.SaveChanges();

            // Completion Marks

            for (userId = 1; userId < usersNumber; userId++)
            {
                for (testId = 1; testId < testsNumber; testId++)
                {
                    db.CompletionMarks.Add(new CompletionMark { UserId = userId, TestId = testId });
                }
            }
            db.SaveChanges();


        }
    }
}
