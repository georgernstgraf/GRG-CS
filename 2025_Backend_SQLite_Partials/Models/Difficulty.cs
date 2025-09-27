using System;
using System.Collections.Generic;

namespace quiz.Models;

public partial class Difficulty
{
    public string Id { get; set; } = null!;

    public string Level { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
