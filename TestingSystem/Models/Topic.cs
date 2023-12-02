using System;
using System.Collections.Generic;

namespace TestingSystem.Models;

public partial class Topic
{
    public int TopicId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
