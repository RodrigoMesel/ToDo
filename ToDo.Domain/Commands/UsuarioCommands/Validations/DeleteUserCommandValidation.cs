namespace ToDo.Domain.Commands.UsuarioCommands.Validations
{
    public class DeleteUserCommandValidation : UserCommandValidation<DeleteUserCommand>
    {
        public DeleteUserCommandValidation()
        {
            ValidateId();
        }
    }
}
