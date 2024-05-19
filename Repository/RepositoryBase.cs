using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            _repositoryContext.Add(entity);
        }

        public void Delete(T entity)
        {
            _repositoryContext.Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _repositoryContext.Set<T>().AsNoTracking() : _repositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _repositoryContext.Set<T>().Where(expression).AsNoTracking() : _repositoryContext.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _repositoryContext.Update(entity);
        }
    }
}
