using Taskify.Core.IService;
using Taskify.Data.Repository.IRepository;
using Taskify.Models;

namespace Taskify.Core
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task CreateTask(TaskItem item)
        {
            await _taskItemRepository.CreateTask(item);
        }

        public async Task DeleteTask(int id)
        {
            await _taskItemRepository.DeleteTask(id);
        }

        public bool Exist(int id)
        {
            return _taskItemRepository.Exist(id);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _taskItemRepository.GetAllTasks();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _taskItemRepository.GetTaskById(id);
        }

        public async Task UpdateTask(TaskItem item)
        {
            await _taskItemRepository.UpdateTask(item);
        }
    }
}
