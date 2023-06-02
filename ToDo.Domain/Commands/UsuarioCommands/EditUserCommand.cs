using ToDo.Domain.Commands.UsuarioCommands.Validations;

namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class EditUserCommand : UsuarioCommand
    {
        public EditUserCommand(Guid id, string name)
        {
            Id = id;    
            Name = name;    
        }

        public override bool IsValid()
        {
            ValidationResult = new EditUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
