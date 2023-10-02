using System;
using System.Collections.Generic;

namespace Lab02.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<CompletionMark> CompletionMarks { get; set; } = new List<CompletionMark>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
