using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab05New.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string Text { get; set; } = null!;

    public int QuestionId { get; set; }
    public virtual Question Question { get; set; } 
}
