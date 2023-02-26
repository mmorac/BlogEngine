using System;
using System.Collections.Generic;

namespace BlogEngine.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Displayname { get; set; }

    public int? Userrole { get; set; }

    public virtual ICollection<Post> PostCreatedbyNavigations { get; } = new List<Post>();

    public virtual ICollection<Post> PostLastmodifiedbyNavigations { get; } = new List<Post>();

    public virtual Userrole? UserroleNavigation { get; set; }
}
