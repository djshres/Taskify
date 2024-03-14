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
            await _taskItemRepository.Create(item);
        }

        public async Task DeleteTask(TaskItem item)
        {
            await _taskItemRepository.Delete(item);
        }

        public bool Exist(int id)
        {
            return _taskItemRepository.Count(x => x.Id == id) == 0;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _taskItemRepository.GetAll();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _taskItemRepository.GetById(id);
        }

        public async Task UpdateTask(TaskItem item)
        {
            await _taskItemRepository.Update(item);
        }
    }
}
