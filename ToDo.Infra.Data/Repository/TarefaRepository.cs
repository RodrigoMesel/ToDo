using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(ToDoDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Tarefa>> GetByStatusAsync(StatusTarefa statusTarefa)
        {
           return await _dbSet.Where(x => x.StatusTarefa == statusTarefa).ToListAsync();    
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Responsavel).ToListAsync();
        }
    }
}
