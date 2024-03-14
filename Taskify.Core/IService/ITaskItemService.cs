using Taskify.Models;

namespace Taskify.Core.IService
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<TaskItem> GetTaskById(int id);
        Task CreateTask(TaskItem item);
        Task UpdateTask(TaskItem item);
        Task DeleteTask(int id);
        bool Exist(int id);
    }
}
