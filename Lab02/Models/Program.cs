using Lab02.Views;
using Lab02.Models;
using System.Collections;
using System.Text;

using (TestingSystemDbContext db = new TestingSystemDbContext())
{
    while (true)
    {
        Console.WriteLine("МЕНЮ");
        Console.WriteLine("1. Вывод всех данных из таблицы Difficulties");
        Console.WriteLine("2. Вывод данных из таблицы Topics, где TopicID больше 2");
        Console.WriteLine("3. Вывод данных о количестве тестов каждой тематики");
        Console.WriteLine("4. Вывод данных из таблиц Questions и Tests");
        Console.WriteLine("5. Вывод данных из таблиц Results и Users, где оценка выше 8.");
        Console.WriteLine("6. Вставка данных в таблицу Topics");
        Console.WriteLine("7. Вставка данных в таблицу Tests");
        Console.WriteLine("8. Удаление данных из таблицы Difficulties");
        Console.WriteLine("9. Удаление данных из таблицы Tests");
        Console.WriteLine("10. Обновление данных таблицы Answers");
        Console.WriteLine("0. ВЫХОД");
        int choiceMenu = Convert.ToInt32(Console.ReadLine());

        switch (choiceMenu)
        {
            case 1:
                PrintConsole(FirstTask(db));
                break;
            case 2:
                PrintConsole(SecondTask(db));
                break;
            case 3:
                PrintConsole(ThirdTask(db));
                break;
            case 4:
                PrintConsole(FourthTask(db));
                break;
            case 5:
                PrintConsole(FifthTask(db));
                break;
            case 6:
                SixthTask(db);
                break;
            case 7:
                SeventhTask(db);
                break;
            case 8:
                EightsTask(db);
                break;
            case 9:
                NinthTask(db);
                break;
            case 10:
                TenthTask(db);
                break;
            case 0:
                return;
        }

        Console.ReadKey();
    }
}

static void Print(IEnumerable items)
{
    Console.WriteLine("Результат: ");
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine();
    Console.ReadKey();
}

static void PrintConsole(string text)
{
    Console.Write(text);
}

static string FirstTask(TestingSystemDbContext db)
{
    StringBuilder stringBuilder = new StringBuilder();

    stringBuilder.AppendLine("Difficulties");

    var difficultiesItems = db.Difficulties.ToList();

    stringBuilder.AppendLine("Id, Name");

    foreach (var item in difficultiesItems)
    {
        stringBuilder.AppendLine($"{item.DifficultyId}, {item.Name}");
    }

    return stringBuilder.ToString();
    //  Print(difficultiesItems.Take(2));
}

static string SecondTask(TestingSystemDbContext db)
{
    StringBuilder stringBuilder = new StringBuilder();

    stringBuilder.AppendLine("Topics, TopicID>2");

    var topicItems = db.Topics.ToList().Where(t => t.TopicId > 2).OrderBy(t => t.TopicId);

    stringBuilder.AppendLine("Id, Name");

    foreach (var item in topicItems)
    {
        stringBuilder.AppendLine($"{item.TopicId}, {item.Name}");
    }

    return stringBuilder.ToString();
}

static string ThirdTask(TestingSystemDbContext db)
{
    StringBuilder stringBuilder = new StringBuilder();

    stringBuilder.AppendLine("Количество тестов каждой тематики.");

    var items = db.Tests.GroupBy(t => t.Topic).Select(g => new { Name = g.Key.Name, NumberOfTests = g.Count() });

    stringBuilder.AppendLine("Name, NumberOfTests");

    foreach (var item in items)
    {
        stringBuilder.AppendLine($"{item.Name} - {item.NumberOfTests}");
    }

    return stringBuilder.ToString();
}

static string FourthTask(TestingSystemDbContext db)
{

    StringBuilder stringBuilder = new StringBuilder();

    stringBuilder.AppendLine("Вопросы с названием теста.");

    var items = db.Questions.Take(10).Select(it => new { Question = it.Name, Test = it.Test.Name });

    stringBuilder.AppendLine("Question, Test");

    foreach (var item in items)
    {
        stringBuilder.AppendLine($"{item.Question}, {item.Test}");
    }

    return stringBuilder.ToString();
}

static string FifthTask(TestingSystemDbContext db)
{
    StringBuilder stringBuilder = new StringBuilder();

    stringBuilder.AppendLine("Результаты пользователей, где оценка выше 8.");

    var items = db.Results.Where(res => res.Mark > 8).Take(10).Select(item => new { User = item.User.Login, Mark = item.Mark, TestId = item.TestId });

    stringBuilder.AppendLine("User, Mark, TestId");

    foreach (var item in items)
    {
        stringBuilder.AppendLine($"{item.User}, {item.Mark}, {item.TestId}");
    }

    return stringBuilder.ToString();

}

static void SixthTask(TestingSystemDbContext db)
{
    Console.WriteLine("Введите название тематики.");
    string name = Console.ReadLine();

    Topic newTopic = new Topic
    {
        Name = name
    };

    db.Topics.Add(newTopic);
    db.SaveChanges();

    Console.WriteLine($"Новая тематика {name} была усешна добавлена.");
}

static void SeventhTask(TestingSystemDbContext db)
{
    Console.WriteLine("Введите название теста.");
    string name = Console.ReadLine();

    Console.WriteLine("Введите id тематики.");
    int topicId = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Введите id сложности.");
    int difficultyId = Convert.ToInt32(Console.ReadLine());

    Test newTest = new Test
    {
        Name = name,
        TopicId = topicId,
        DifficultyId = difficultyId
    };


    db.Tests.Add(newTest);
    db.SaveChanges();

    Console.WriteLine("Запись в таблицу тест успешно добавлена.");
}

static void EightsTask(TestingSystemDbContext db)
{
    Console.WriteLine("Введите id сложности для удаления.");
    int difficultyId = Convert.ToInt32(Console.ReadLine());

    Difficulty difficultyToDelete = db.Difficulties.FirstOrDefault(diff => diff.DifficultyId == difficultyId);

    if (difficultyToDelete != null)
    {
        db.Difficulties.Remove(difficultyToDelete);
        db.SaveChanges();
    }

    Console.WriteLine($"Сложость с индексом {difficultyId} была успешно удалена.");
}

static void NinthTask(TestingSystemDbContext db)
{
    Console.WriteLine("Введите id теста для удаления.");
    int testId = Convert.ToInt32(Console.ReadLine());

    Test testToDelete = db.Tests.FirstOrDefault(test => test.TestId == testId);

    if (testToDelete != null)
    {
        db.Tests.Remove(testToDelete);
        db.SaveChanges();
    }

    Console.WriteLine($"Тест с индексом {testId} был успешно удалён.");
}

static void TenthTask(TestingSystemDbContext db)
{
    Console.WriteLine("Введите начальное значение id вопроса");
    int questionStartId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите конечное значение id вопроса");
    int questionEndId = Convert.ToInt32(Console.ReadLine());

    var answersToUpdate = db.Answers.Where(answ => answ.QuestionId >= questionStartId && answ.QuestionId <= questionEndId).ToList();

    foreach (var item in answersToUpdate)
    {
        item.Text += "TEST1";
    }

    db.SaveChanges();

    Console.WriteLine("Изменения были сохранены.");

}

