using AutoMapper;
using Taskify.Core.IService;
using Taskify.Data.Repository.IRepository;
using Taskify.Models;
using Taskify.Models.ViewModel;

namespace Taskify.Core
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public TaskItemService(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task CreateTask(TaskItemViewModel item)
        {
            var taskItem = _mapper.Map<TaskItem>(item);
            await _taskItemRepository.Create(taskItem);
        }

        public async Task DeleteTask(int id)
        {
            var item = await _taskItemRepository.GetById(id);
            var taskItem = _mapper.Map<TaskItem>(item);
            await _taskItemRepository.Delete(taskItem);
        }

        public bool Exist(int id)
        {
            return _taskItemRepository.Count(x => x.Id == id) != 0;
        }

        public async Task<IEnumerable<TaskItemViewModel>> GetAllTasks()
        {
            var taskItems = await _taskItemRepository.GetAll();
            var taskItemViewModels = _mapper.Map<IEnumerable<TaskItemViewModel>>(taskItems);
            return taskItemViewModels;
        }

        public async Task<TaskItemViewModel> GetTaskById(int id)
        {
            var taskItem = await _taskItemRepository.GetById(id);
            var taskItemViewModel = _mapper.Map<TaskItemViewModel>(taskItem);
            return taskItemViewModel;
        }

        public async Task UpdateTask(TaskItemViewModel item)
        {
            var taskItem = _mapper.Map<TaskItem>(item);
            await _taskItemRepository.Update(taskItem);
        }
    }
}
