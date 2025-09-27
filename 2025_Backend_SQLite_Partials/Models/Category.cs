using System;
using System.Collections.Generic;

namespace quiz.Models;

public partial class Category
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int OpentdbId { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
