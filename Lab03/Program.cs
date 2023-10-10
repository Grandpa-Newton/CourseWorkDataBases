using Lab03;
using Lab03.Models;
using Lab03.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;

Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
}).Build().Run();

/*var builder = WebApplication.CreateBuilder(args);


string connectionString = "Server=MSI;Database=TestingSystemDb;Trusted_Connection=True;";
builder.Services.AddDbContext<TestingSystemDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<CachedAnswersService>();
builder.Services.AddTransient<CachedCompletionMarksService>();
builder.Services.AddTransient<CachedDifficultiesService>();
builder.Services.AddTransient<CachedQuestionsService>();
builder.Services.AddTransient<CachedResultsService>();
builder.Services.AddTransient<CachedTestsService>();
builder.Services.AddTransient<CachedTopicsService>();
builder.Services.AddTransient<CachedUsersService>();

builder.Services.AddMemoryCache();

var app = builder.Build();

app.Map("/answers", (CachedAnswersService answerService) =>
{
    List<Answer> answers = answerService.GetAnswers().ToList();
    if (answers != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var answer in answers)
        {
            stringBuilder.Append($"Answer {answer.Text} Id = {answer.AnswerId}  QuestionId = {answer.QuestionId}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Answers not found";
});
app.Map("/completionmarks", (CachedCompletionMarksService completionMarksService) =>
{
    List<CompletionMark> completionMarks = completionMarksService.GetCompletionMarks().ToList();
    if (completionMarks != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var completionMark in completionMarks)
        {
            stringBuilder.Append($"Completion Mark Id {completionMark.CompletionMarkId} UserId = {completionMark.UserId}  Mark = {completionMark.Mark}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Answers not found";
});
app.Map("/difficulties", (CachedDifficultiesService difficultiesService) =>
{
    List<Difficulty> difficulties = difficultiesService.GetDifficulties().ToList();
    if (difficulties != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var difficulty in difficulties)
        {
            stringBuilder.Append($"Difficulty {difficulty.Name} Id = {difficulty.DifficultyId}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Difficulties not found";
});
app.Map("/questions", (CachedQuestionsService questionService) =>
{
    List<Question> questions = questionService.GetQuestions().ToList();
    if (questions != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var question in questions)
        {
            stringBuilder.Append($"Question {question.Name} Id = {question.QuestionId}  Text = {question.Text}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Questions not found";
});
app.Map("/results", (CachedResultsService resultService) =>
{
    List<Result> results = resultService.GetResults().ToList();
    if (results != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var result in results)
        {
            stringBuilder.Append($"TestId = {result.TestId}   UserId = {result.UserId}  Mark = {result.Mark}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Results not found";
});
app.Map("/tests", (CachedTestsService testService) =>
{
    List<Test> tests = testService.GetTests().ToList();
    if (tests != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var test in tests)
        {
            stringBuilder.Append($"Test {test.Name} Id = {test.TestId}  TopicId = {test.TopicId}  DifficultyId = {test.DifficultyId}   NumberOfQuestions = {test.NumberOfQuestions}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Tests not found";
});
app.Map("/topics", (CachedTopicsService topicService) =>
{
    List<Topic> topics = topicService.GetTopics().ToList();
    if (topics != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var topic in topics)
        {
            stringBuilder.Append($"Topic {topic.Name} Id = {topic.TopicId}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Topics not found";
});
app.Map("/users", (CachedUsersService userService) =>
{
    List<User> users = userService.GetUsers().ToList();
    if (users != null)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var user in users)
        {
            stringBuilder.Append($"User {user.Login} Id = {user.UserId}  Password = {user.Password}  Name = {user.Name}   Surname = {user.Surname}" +
                $"  Email = {user.Email}" + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
    return "Users not found";
});
app.Map("/", () => "Hello World!");


app.Run();*/

/*// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();*/
