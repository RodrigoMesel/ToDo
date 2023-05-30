namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class EditUserCommand : UsuarioCommand
    {
        public EditUserCommand(Guid id, string name)
        {
            Id = id;    
            Name = name;    
        }
    }
}
