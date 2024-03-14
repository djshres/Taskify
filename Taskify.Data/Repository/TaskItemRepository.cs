using Taskify.Data.Repository.IRepository;
using Taskify.Models;

namespace Taskify.Data.Repository
{
    public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(TaskifyContext context) : base(context)
        {
        }
    }
}