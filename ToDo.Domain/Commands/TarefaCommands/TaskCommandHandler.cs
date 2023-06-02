using MediatR;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.Domain.Commands.TarefaCommands
{
    public class TaskCommandHandler :
        IRequestHandler<AddTaskCommand, bool>,
        IRequestHandler<EditTaskCommand, bool>,
        IRequestHandler<DeleteTaskCommand, bool>
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TaskCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }


        public async Task<bool> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            // Não consegui pensar em um jeito de fazer uma verificação

            var newTask = new Tarefa(
                request.Id,
                request.Descricao,
                request.IdResponsavel,
                request.DataPrevista,
                request.StatusTarefa);

            _tarefaRepository.Add(newTask);
            //return await _tarefaRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var exisistingTask = await _tarefaRepository.GetByIdAsync(request.Id);

            if (exisistingTask == null)
            {
                return false;
            }

            _tarefaRepository.Delete(exisistingTask);
            //return await _tarefaRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {
            var existingTask = await _tarefaRepository.GetByIdAsync(request.Id);
            if (existingTask == null)
            {
                return false;
            }

            var newTask = new Tarefa(
                request.Id,
                request.Descricao,
                request.IdResponsavel,
                request.DataPrevista,
                request.StatusTarefa);

            _tarefaRepository.Update(newTask);
            //return await _tarefaRepository.SaveChangesAsync();
            return true;
        }
    }
}
