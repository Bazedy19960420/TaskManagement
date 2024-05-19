using Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        ILoggerManager _loggerManager;
        public TaskController(IServiceManager serviceManager, ILoggerManager loggerManager)
        {
            _serviceManager = serviceManager;
            _loggerManager = loggerManager;
        }
        [HttpGet]
        public IActionResult GetTasks()
        {

            var tasks = _serviceManager.taskService.GetAllTasks(trackChanges: false);
            return Ok(tasks);
        }
        [HttpGet("{id:int}", Name = "GetTaskById")]
        public IActionResult GetTask(int id)
        {
            var task = _serviceManager.taskService.GetTask(id, trackChanges: false);
            return Ok(task);
        }
        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDto task)
        {

            if (task == null)
                return BadRequest("Task is Null");
            var createdTask = _serviceManager.taskService.CreateTask(task);
            return Created();

        }
        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            _serviceManager.taskService.DeleteTask(id, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskDto task)
        {
            _serviceManager.taskService.UpdateTask(id, trackChanges: true, task);
            return Ok();
        }

    }
}
