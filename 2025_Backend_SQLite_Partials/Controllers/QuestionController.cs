using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz.Models;
using quiz.Models.ViewModels;

namespace quiz.Controllers;

public sealed class QuestionController : Controller
{
    private readonly OpentdbContext _context;
    private readonly ILogger<QuestionController> _logger;

    public QuestionController(OpentdbContext context, ILogger<QuestionController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 25)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize is < 1 or > 100 ? 25 : pageSize;

        var query = _context.Questions
            .AsNoTracking()
            .Include(q => q.Category)
            .Include(q => q.Difficulty)
            .Include(q => q.Type)
            .Include(q => q.CorrectAnswer)
            .OrderBy(q => q.Id);

        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (items.Count == 0)
        {
            _logger.LogInformation("No questions returned for page {Page} with page size {PageSize}.", page, pageSize);
        }

        var viewModel = new QuestionIndexViewModel
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };

        return View(viewModel);
    }
}
