using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositorycontext;
        private readonly ITaskRepository _taskRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositorycontext = repositoryContext;
            _taskRepository = new TaskRepository(repositoryContext);
        }
        public ITaskRepository TaskRepository => _taskRepository;
        public void Save() => _repositorycontext.SaveChanges();
    }
}
