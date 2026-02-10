using Microsoft.EntityFrameworkCore;
using TodoAPIexercise.Models; // där din Item-klass ligger

namespace TodoAPIexercise.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Items { get; set; }
    }
}
