
namespace ToDo.Domain.Commands.TarefaCommands
{
    public class DeleteTaskCommand : TaskCommand
    {
        public DeleteTaskCommand(Guid taskId) 
        {
            Id = taskId;
        }
    }
}
