using Microsoft.EntityFrameworkCore;

namespace quiz.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Add your DbSet properties here
        // Example: public DbSet<Question> Questions { get; set; }
        // Example: public DbSet<Answer> Answers { get; set; }
    }
}
