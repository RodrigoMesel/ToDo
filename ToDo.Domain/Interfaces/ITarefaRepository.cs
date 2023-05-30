using ToDo.Domain.Core.Interfaces;
using ToDo.Domain.Enums;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        IQueryable<Tarefa> GetByStatus(StatusTarefa statusTarefa);
    }
}
