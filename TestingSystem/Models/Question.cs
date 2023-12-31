﻿using System;
using System.Collections.Generic;

namespace TestingSystem.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string Name { get; set; } = null!;

    public string Text { get; set; } = null!;

    public int TestId { get; set; }

    public int NumberOfPoints { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Test Test { get; set; } = null!;
}
