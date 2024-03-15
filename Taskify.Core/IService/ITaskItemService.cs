using Taskify.Models.ViewModel;

namespace Taskify.Core.IService
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItemViewModel>> GetAllTasks();
        Task<TaskItemViewModel> GetTaskById(int id);
        Task CreateTask(TaskItemViewModel item);
        Task UpdateTask(TaskItemViewModel item);
        Task DeleteTask(int id);
        bool Exist(int id);
    }
}
