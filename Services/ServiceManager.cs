using AutoMapper;
using Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ITaskService _taskService;

        public ServiceManager(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager)
        {

            _taskService = new TaskService(mapper, repositoryManager, loggerManager);
        }
        public ITaskService taskService => _taskService;
    }
}
