namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class DeleteUserCommand : UsuarioCommand
    {
        public DeleteUserCommand(Guid userId) {
            Id = userId;
        }  
    }
}
