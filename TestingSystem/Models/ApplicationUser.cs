﻿using Microsoft.AspNetCore.Identity;

namespace TestingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<CompletionMark> CompletionMarks { get; set; } = new List<CompletionMark>();

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
