namespace Contracts
{
    public interface IRepositoryManager
    {
        ITaskRepository TaskRepository { get; }
        void Save();
    }
}
