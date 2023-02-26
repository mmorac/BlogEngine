using System;
using System.Collections.Generic;

namespace BlogEngine.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? Postid { get; set; }

    public string? Content { get; set; }

    public virtual Post? Post { get; set; }
}
