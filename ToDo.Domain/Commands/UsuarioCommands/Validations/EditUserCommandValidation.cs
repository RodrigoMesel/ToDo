using ToDo.Domain.Commands.UsuarioCommands;

namespace ToDo.Domain.Commands.UsuarioCommands.Validations
{
    public class EditUserCommandValidation : UserCommandValidation<EditUserCommand>
    {
        public EditUserCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
