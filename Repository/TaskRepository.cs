using Contracts;
using Entities;

namespace Repository
{
    public class TaskRepository : RepositoryBase<TaskEvent>, ITaskRepository
    {
        public TaskRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateTask(TaskEvent task)
        {
            Create(task);
        }

        public void DeleteTask(TaskEvent task)
        {
            Delete(task);
        }

        public IEnumerable<TaskEvent> GetAllTasks(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public TaskEvent GetTask(int id, bool trackChanges)
        {
            return FindByCondition(c => c.Id == id, trackChanges).FirstOrDefault();
        }


    }
}
