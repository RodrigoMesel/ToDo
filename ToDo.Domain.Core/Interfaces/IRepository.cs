using ToDo.Domain.Core.Models;

namespace ToDo.Domain.Core.Interfaces
{
    public interface IRepository<T> where T: Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}
