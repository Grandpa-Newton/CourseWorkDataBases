using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Lab05New.Models;

public partial class User : IdentityUser
{
  //  public int UserId { get; set; }

    public string Login { get; set; } = null!; // UserName

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

  //  public virtual ApplicationUser? ApplicationUser { get; set; }
}
