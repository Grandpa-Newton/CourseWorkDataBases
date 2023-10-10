using System;
using System.Collections.Generic;

namespace Lab03.Models;

public partial class CompletionMark
{
    public int CompletionMarkId { get; set; }

    public int UserId { get; set; }

    public int TestId { get; set; }

    public bool Mark { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
