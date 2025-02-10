using Caarta.Data.Entities.Abstractions;
using System.Linq.Expressions;

namespace Caarta.Data.Repositories.Abstractions
{
    //an interface for the CRUD methods
    public interface ICrudRepository<T>
        where T : BaseEntity
    {
        public Task AddAsync(T entity);
        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task UpdateAsync(T entity);
        public Task DeleteByIdAsync(int id);
    }
}
