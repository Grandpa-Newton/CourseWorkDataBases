using System;
using System.Collections.Generic;

namespace Lab05New.Models;

public partial class CompletionMark
{
    public int CompletionMarkId { get; set; }

    public string ApplicationUserId { get; set; }

    public int TestId { get; set; }

    public bool Mark { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
