using System;
using System.Collections.Generic;

namespace quiz.Models;

public partial class Type
{
    public string Id { get; set; } = null!;

    public string Type1 { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
