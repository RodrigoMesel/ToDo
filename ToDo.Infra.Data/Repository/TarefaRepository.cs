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

        public IQueryable<Tarefa> GetByStatus(StatusTarefa statusTarefa)
        {
           return _dbSet.Where(x => x.StatusTarefa == statusTarefa);    
        }
    }
}
