using MediatR;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class UsuarioCommandHandler : 
        IRequestHandler<AddUserCommand, bool>,
        IRequestHandler<EditUserCommand, bool>,
        IRequestHandler<DeleteUserCommand, bool>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //valida se dados usuário válido

            var existingUser = await _usuarioRepository.GetByNameAsync(request.Name);

            if (existingUser != null) {
                return false;
            }

            var newUser = new Usuario(request.Id, request.Name);
            _usuarioRepository.Add(newUser);
            return await _usuarioRepository.SaveChangesAsync();
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //valida se dados usuário válido

            var existingUser = await _usuarioRepository.GetByIdAsync(request.Id);

            if (existingUser is null) {
                return false;
            }

            _usuarioRepository.Delete(existingUser);
            return await _usuarioRepository.SaveChangesAsync();
        }

        public async Task<bool> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //valida se dados usuário válido

            var existingUser = await _usuarioRepository.GetByNameAsync(request.Name);

            if (existingUser != null && existingUser.Id != request.Id)
            {
                return false;
            }

            var newUser = new Usuario(request.Id, request.Name);
            _usuarioRepository.Update(newUser);
            return await _usuarioRepository.SaveChangesAsync();
        }
    }
}
