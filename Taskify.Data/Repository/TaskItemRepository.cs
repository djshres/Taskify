using Microsoft.EntityFrameworkCore;
using Taskify.Data.Repository.IRepository;
using Taskify.Models;

namespace Taskify.Data.Repository
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TaskifyContext _context;

        public TaskItemRepository(TaskifyContext context)
        {
            _context = context;
        }

        public async Task CreateTask(TaskItem item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var taskItem = await _context.TaskItem.FindAsync(id);

            if (taskItem != null)
            {
                _context.TaskItem.Remove(taskItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _context.TaskItem.ToListAsync();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _context.TaskItem.FindAsync(id);
        }

        public async Task UpdateTask(TaskItem item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public bool Exist(int id)
        {
            return _context.TaskItem.Any(e => e.Id == id);
        }
    }
}