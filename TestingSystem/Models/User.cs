using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TestingSystem.Models;

public partial class User : IdentityUser
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;
}
