using System;
using System.Collections.Generic;

namespace BlogEngine.Models;

public partial class Userrole
{
    public int Id { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
