using ToDo.Domain.Commands.UsuarioCommands;

namespace ToDo.Domain.Commands.UsuarioCommands.Validations
{
    public class AddUserCommandValidation : UserCommandValidation<AddUserCommand>
    {
        public AddUserCommandValidation()
        {
            ValidateName();
        }
    }
}
