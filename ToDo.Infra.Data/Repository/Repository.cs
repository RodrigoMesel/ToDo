using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Core.Interfaces;
using ToDo.Domain.Core.Models;
using ToDo.Domain.Models;
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

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(u => u.Id == id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
