using FluentValidation.Results;
using ToDo.Application.ViewModels;

namespace ToDo.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<ValidationResult> AddAsync(UsuarioViewModel usuarioViewModel);
        Task<ValidationResult> UpdateAsync(UsuarioViewModel usuarioViewModel);
        Task<ValidationResult> DeleteAsync(Guid userId);
        Task<IEnumerable<UsuarioViewModel>> GetAllAsync();
        Task<UsuarioViewModel> GetByIdAsync(Guid id);
    }
}
