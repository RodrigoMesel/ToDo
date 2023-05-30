using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Core.Interfaces;
using ToDo.Domain.Core.Models;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ToDoDbContext _db;
        protected readonly DbSet<T> _dbSet;

        public Repository(ToDoDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
