using System;
using System.Collections.Generic;

namespace quiz.Models;

public partial class Question
{
    public string Id { get; set; } = null!;

    public string Question1 { get; set; } = null!;

    public string CorrectAnswerId { get; set; } = null!;

    public string DifficultyId { get; set; } = null!;

    public string CategoryId { get; set; } = null!;

    public string TypeId { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Answer CorrectAnswer { get; set; } = null!;

    public virtual Difficulty Difficulty { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
