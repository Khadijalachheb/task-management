
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(TaskP task)
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.TaskId }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskP task)
        {
            if (id != task.TaskId)
            {
                return BadRequest();
            }
            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}