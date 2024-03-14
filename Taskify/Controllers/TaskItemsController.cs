using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskify.Core.IService;
using Taskify.Models;
using Taskify.Models.ViewModel;

namespace Taskify.Controllers
{
    public class TaskItemsController : Controller
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemsController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        // GET: TaskItems
        public async Task<IActionResult> Index()
        {
            return View(await _taskItemService.GetAllTasks());
        }

        // GET: TaskItems/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var taskItem = await _taskItemService.GetTaskById(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // GET: TaskItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItemViewModel taskItem)
        {
            if (ModelState.IsValid)
            {
                await _taskItemService.CreateTask(taskItem);
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskItems/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var taskItem = await _taskItemService.GetTaskById(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return View(taskItem);
        }

        // POST: TaskItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItemViewModel taskItem)
        {
            if (id != taskItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _taskItemService.UpdateTask(taskItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskItemExists(taskItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskItems/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var taskItem = await _taskItemService.GetTaskById(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _taskItemService.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemExists(int id)
        {
            return _taskItemService.Exist(id);
        }
    }
}
