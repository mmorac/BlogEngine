using System;
using System.Collections.Generic;

namespace BlogEngine.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? Createdby { get; set; }

    public int? Lastmodifiedby { get; set; }

    public int? Statusid { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual User? CreatedbyNavigation { get; set; }

    public virtual User? LastmodifiedbyNavigation { get; set; }

    public virtual Poststatus? Status { get; set; }
}
