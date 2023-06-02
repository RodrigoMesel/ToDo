using FluentValidation.Results;
using ToDo.Domain.Commands.UsuarioCommands.Validations;

namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class AddUserCommand : UsuarioCommand
    {
        public AddUserCommand(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;    
        }

        public override bool IsValid()
        {
            ValidationResult = new AddUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
