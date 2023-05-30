using ToDo.Application.ViewModels;

namespace ToDo.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> AddAsync(UsuarioViewModel usuarioViewModel);
        Task<bool> UpdateAsync(UsuarioViewModel usuarioViewModel);
        Task<bool> DeleteAsync(Guid userId);
        Task<IEnumerable<UsuarioViewModel>> GetAllAsync();
        Task<UsuarioViewModel> GetByIdAsync(Guid id);
    }
}
