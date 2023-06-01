using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.ViewModels;
using ToDo.Domain.Enums;

namespace ToDo.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<bool> AddAsync(TarefaViewModel tarefaViewModel);
        Task<bool> UpdateAsync(TarefaViewModel tarefaViewModel);
        Task<bool> DeleteAsync(Guid taskId);
        Task<IEnumerable<TarefaViewModel>> GetAllAsync();
        Task<TarefaViewModel> GetByIdAsync(Guid id);
        Task<IEnumerable<TarefaViewModel>> GetByStatusAsync(StatusTarefa statusTarefa);
    }
}
