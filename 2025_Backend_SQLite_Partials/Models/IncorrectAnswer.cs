using System;
using System.Collections.Generic;

namespace quiz.Models;

public partial class IncorrectAnswer
{
    public string A { get; set; } = null!;

    public string B { get; set; } = null!;

    public virtual Answer ANavigation { get; set; } = null!;

    public virtual Question BNavigation { get; set; } = null!;
}
