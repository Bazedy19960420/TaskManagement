using AutoMapper;
using Contracts;
using Entities;
using Shared.DTO;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public TaskService(IMapper mapper, IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public TaskDto CreateTask(TaskDto task)
        {
            var taskEntity = _mapper.Map<TaskEvent>(task);
            _repositoryManager.TaskRepository.CreateTask(taskEntity);
            _repositoryManager.Save();
            return task;
        }

        public void DeleteTask(int id, bool trackChanges)
        {
            var task = _repositoryManager.TaskRepository.GetTask(id, trackChanges);
            if (task != null)
            {
                _repositoryManager.TaskRepository.DeleteTask(task);
                _repositoryManager.Save();
            }
        }

        public IEnumerable<TaskDto> GetAllTasks(bool trackChanges)
        {
            var tasks = _repositoryManager.TaskRepository.GetAllTasks(trackChanges);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public TaskDto GetTask(int id, bool trackChanges)
        {
            var task = _repositoryManager.TaskRepository.GetTask(id, trackChanges);
            return _mapper.Map<TaskDto>(task);
        }

        public void UpdateTask(int id, bool trackChanges, TaskDto task)
        {
            var taskEvent = _repositoryManager.TaskRepository.GetTask(id, trackChanges);
            if (taskEvent != null)
            {
                _mapper.Map(task, taskEvent);
                _repositoryManager.Save();
            }
        }


    }
}
