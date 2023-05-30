using MediatR;

namespace ToDo.Domain.Commands.UsuarioCommands
{
    public class UsuarioCommand : IRequest<bool>
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}
