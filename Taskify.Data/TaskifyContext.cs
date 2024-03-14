using Microsoft.EntityFrameworkCore;
using Taskify.Models;

namespace Taskify.Data
{
    public class TaskifyContext : DbContext
    {
        public TaskifyContext(DbContextOptions<TaskifyContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> TaskItem { get; set; } = default!;
    }
}
