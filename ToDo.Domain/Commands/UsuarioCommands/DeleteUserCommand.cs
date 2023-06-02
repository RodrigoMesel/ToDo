using ToDo.Domain.Commands.UsuarioCommands.Validations;

namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class DeleteUserCommand : UsuarioCommand
    {
        public DeleteUserCommand(Guid userId) {
            Id = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
