using MediatR;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Commands.TarefaCommands
{
    public class TaskCommand : IRequest<bool>
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public Guid IdResponsavel { get; protected set; }
        public DateTime DataPrevista { get; protected set; }
        public StatusTarefa StatusTarefa { get; protected set; }

    }
}
