using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Core.Interfaces;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class UsuarioCommandHandler : BaseCommandHandler,
        IRequestHandler<AddUserCommand, ValidationResult>,
        IRequestHandler<EditUserCommand, ValidationResult>,
        IRequestHandler<DeleteUserCommand, ValidationResult>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork uow) : base(uow)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var existingUser = await _usuarioRepository.GetByNameAsync(request.Name);

            if (existingUser != null) {
                AddError("Já existe um usuário com o nome informado.");
                return _validationResult;
            }

            var newUser = new Usuario(request.Id, request.Name);
            _usuarioRepository.Add(newUser);
            await CommitAsync();

            return _validationResult;
        }

        public async Task<ValidationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var existingUser = await _usuarioRepository.GetByIdAsync(request.Id);

            if (existingUser is null) {
                AddError("Usuário não encontrado.");
                return _validationResult;
            }

            _usuarioRepository.Delete(existingUser);
            await CommitAsync();

            return _validationResult;
        }

        public async Task<ValidationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var existingUser = await _usuarioRepository.GetByNameAsync(request.Name);

            if (existingUser != null && existingUser.Id != request.Id)
            {
                AddError("Foram encontradas inconsistências nas informações.");
                return _validationResult;
            }

            var newUser = new Usuario(request.Id, request.Name);
            _usuarioRepository.Update(newUser);
            await CommitAsync();

            return _validationResult;
        }
    }
}
