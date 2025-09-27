using System.Collections.Generic;
using quiz.Models;

namespace quiz.Models.ViewModels;

public sealed class QuestionIndexViewModel
{
    public required IReadOnlyList<Question> Items { get; init; }

    public required int TotalCount { get; init; }

    public required int Page { get; init; }

    public required int PageSize { get; init; }

    public int TotalPages => (int)System.Math.Ceiling((double)TotalCount / PageSize);
}
