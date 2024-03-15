using AutoMapper;
using Moq;
using Taskify.Core.IService;
using Taskify.Data.Repository.IRepository;
using Taskify.Models;
using Taskify.Models.ViewModel;

namespace Taskify.Core.Tests
{
    [TestFixture]
    public class TaskItemServiceTests
    {
        private Mock<ITaskItemRepository> _mockTaskItemRepository;
        private Mock<IMapper> _mockMapper;
        private ITaskItemService _taskItemService;

        [SetUp]
        public void Setup()
        {
            _mockTaskItemRepository = new Mock<ITaskItemRepository>();
            _mockMapper = new Mock<IMapper>();
            _taskItemService = new TaskItemService(_mockTaskItemRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task CreateTask_ValidTaskItemViewModel_CreatesTaskItem()
        {
            // Arrange
            var taskItemViewModel = new TaskItemViewModel { };
            var taskItem = new TaskItem { };
            _mockMapper.Setup(m => m.Map<TaskItem>(taskItemViewModel)).Returns(taskItem);

            // Act
            await _taskItemService.CreateTask(taskItemViewModel);

            // Assert
            _mockTaskItemRepository.Verify(r => r.Create(taskItem), Times.Once);
        }

        [Test]
        public void Exist_ExistingId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _mockTaskItemRepository.Setup(r => r.Count(It.IsAny<Func<TaskItem, bool>>())).Returns(1);

            // Act
            var result = _taskItemService.Exist(id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Exist_NonExistingId_ReturnsFalse()
        {
            // Arrange
            var id = 1;
            _mockTaskItemRepository.Setup(r => r.Count(It.IsAny<Func<TaskItem, bool>>())).Returns(0);

            // Act
            var result = _taskItemService.Exist(id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetAllTasks_ReturnsListOfTaskItemViewModels()
        {
            // Arrange
            var taskItems = new List<TaskItem> { };
            var taskItemViewModels = new List<TaskItemViewModel> { };
            _mockTaskItemRepository.Setup(r => r.GetAll()).ReturnsAsync(taskItems.AsEnumerable());
            _mockMapper.Setup(m => m.Map<IEnumerable<TaskItemViewModel>>(taskItems)).Returns(taskItemViewModels);

            // Act
            var result = await _taskItemService.GetAllTasks();

            // Assert
            Assert.AreEqual(taskItemViewModels, result);
        }

        [Test]
        public async Task GetTaskById_ExistingId_ReturnsTaskItemViewModel()
        {
            // Arrange
            var id = 1;
            var taskItem = new TaskItem { };
            var taskItemViewModel = new TaskItemViewModel { };
            _mockTaskItemRepository.Setup(r => r.GetById(id)).ReturnsAsync(taskItem);
            _mockMapper.Setup(m => m.Map<TaskItemViewModel>(taskItem)).Returns(taskItemViewModel);

            // Act
            var result = await _taskItemService.GetTaskById(id);

            // Assert
            Assert.AreEqual(taskItemViewModel, result);
        }

        [Test]
        public async Task GetTaskById_NonExistingId_ReturnsNull()
        {
            // Arrange
            var id = 1;
            _mockTaskItemRepository.Setup(r => r.GetById(id)).ReturnsAsync((TaskItem)null);

            // Act
            var result = await _taskItemService.GetTaskById(id);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task UpdateTask_ValidTaskItemViewModel_UpdatesTaskItem()
        {
            // Arrange
            var taskItemViewModel = new TaskItemViewModel { };
            var taskItem = new TaskItem { };
            _mockMapper.Setup(m => m.Map<TaskItem>(taskItemViewModel)).Returns(taskItem);

            // Act
            await _taskItemService.UpdateTask(taskItemViewModel);

            // Assert
            _mockTaskItemRepository.Verify(r => r.Update(taskItem), Times.Once);
        }
    }
}
