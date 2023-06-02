using FluentValidation.Results;
using MediatR;

namespace ToDo.Domain.Commands.UsuarioCommands
{
    public abstract class UsuarioCommand : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; }
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public abstract bool IsValid();
    }
}
