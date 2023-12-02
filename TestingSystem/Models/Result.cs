using System;
using System.Collections.Generic;

namespace TestingSystem.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int Mark { get; set; }

    public int TestId { get; set; }

    public string ApplicationUserId { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
