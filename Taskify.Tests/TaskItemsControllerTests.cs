using Microsoft.AspNetCore.Mvc;
using Moq;
using Taskify.Controllers;
using Taskify.Core.IService;
using Taskify.Models.ViewModel;

namespace Taskify.Tests
{
    [TestFixture]
    public class TaskItemsControllerTests
    {
        private Mock<ITaskItemService> _mockTaskItemService;
        private TaskItemsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockTaskItemService = new Mock<ITaskItemService>();
            _controller = new TaskItemsController(_mockTaskItemService.Object);
        }

        [Test]
        public async Task Index_ReturnsViewWithTaskItems()
        {
            // Arrange
            var taskItems = new List<TaskItemViewModel> { };
            _mockTaskItemService.Setup(s => s.GetAllTasks()).ReturnsAsync(taskItems);

            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(taskItems, result.Model);
        }

        [Test]
        public async Task Details_ExistingId_ReturnsViewWithTaskItem()
        {
            // Arrange
            var id = 1;
            var taskItem = new TaskItemViewModel { };
            _mockTaskItemService.Setup(s => s.GetTaskById(id)).ReturnsAsync(taskItem);

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(taskItem, result.Model);
        }

        [Test]
        public async Task Create_InvalidModelState_ReturnsViewWithError()
        {
            // Arrange
            var taskItem = new TaskItemViewModel { };
            _controller.ModelState.AddModelError("PropertyName", "Error message");

            // Act
            var result = await _controller.Create(taskItem) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
            Assert.AreEqual(taskItem, result.Model);
        }

        [Test]
        public async Task DeleteConfirmed_ExistingId_DeletesTaskItemAndRedirectsToIndex()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            _mockTaskItemService.Verify(s => s.DeleteTask(id), Times.Once);
        }
    }
}
