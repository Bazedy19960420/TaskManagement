using Entities;

namespace Contracts
{
    public interface ITaskRepository
    {
        IEnumerable<TaskEvent> GetAllTasks(bool trackChanges);
        TaskEvent GetTask(int id, bool trackChanges);
        void CreateTask(TaskEvent task);
        void DeleteTask(TaskEvent task);

    }
}
