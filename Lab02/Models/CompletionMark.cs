using System;
using System.Collections.Generic;

namespace Lab02.Models;

public partial class CompletionMark
{
    public int CompletionMarkId { get; set; }

    public int UserId { get; set; }

    public int TestId { get; set; }

    public bool CompletionMark1 { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
