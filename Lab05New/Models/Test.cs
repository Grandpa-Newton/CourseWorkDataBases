using System;
using System.Collections.Generic;

namespace Lab05New.Models;

public partial class Test
{
    public int TestId { get; set; }

    public string Name { get; set; } = null!;

    public int TopicId { get; set; }

    public int DifficultyId { get; set; }

    public int NumberOfQuestions { get; set; }

    public virtual ICollection<CompletionMark> CompletionMarks { get; set; } = new List<CompletionMark>();

    public virtual Difficulty Difficulty { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Topic Topic { get; set; } = null!;
}
