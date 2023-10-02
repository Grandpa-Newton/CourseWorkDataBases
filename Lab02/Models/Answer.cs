using System;
using System.Collections.Generic;

namespace Lab02.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string Text { get; set; } = null!;

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;
}
