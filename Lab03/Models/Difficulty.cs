using System;
using System.Collections.Generic;

namespace Lab03.Models;

public partial class Difficulty
{
    public int DifficultyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
