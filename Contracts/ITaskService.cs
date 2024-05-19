using Shared.DTO;

namespace Contracts
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks(bool trackChanges);
        TaskDto GetTask(int id, bool trackChanges);
        TaskDto CreateTask(TaskDto task);
        void DeleteTask(int id, bool trackChanges);
        void UpdateTask(int id, bool trackChanges, TaskDto task);
    }
}
