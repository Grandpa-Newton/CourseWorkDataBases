using System;
using System.Collections.Generic;

namespace Lab02.Views;

public partial class TestsWithNumberOfQuestion
{
    public string TestName { get; set; } = null!;

    public int NumberOfQuestions { get; set; }

    public string Difficulty { get; set; } = null!;

    public string Topic { get; set; } = null!;
}
