using Taskify.Models;

namespace Taskify.Data.Repository.IRepository
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<TaskItem> GetTaskById(int id);
        Task CreateTask(TaskItem item);
        Task UpdateTask(TaskItem item);
        Task DeleteTask(int id);
        bool Exist(int id);
    }
}
