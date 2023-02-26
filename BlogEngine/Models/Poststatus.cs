using System;
using System.Collections.Generic;

namespace BlogEngine.Models;

public partial class Poststatus
{
    public int Id { get; set; }

    public string? Statusname { get; set; }

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
