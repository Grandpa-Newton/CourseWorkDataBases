using System;
using System.Collections.Generic;

namespace Lab04.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int Mark { get; set; }

    public int TestId { get; set; }

    public int UserId { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
