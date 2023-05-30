namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class AddUserCommand : UsuarioCommand
    {
        public AddUserCommand(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;    
        }
    }
}
