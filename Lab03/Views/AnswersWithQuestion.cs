using System;
using System.Collections.Generic;

namespace Lab03.Views;

public partial class AnswersWithQuestion
{
    public string QuestionName { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public string TestName { get; set; } = null!;
}
