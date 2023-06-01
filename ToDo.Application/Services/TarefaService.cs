using AutoMapper;
using MediatR;
using ToDo.Application.Interfaces;
using ToDo.Application.ViewModels;
using ToDo.Domain.Commands.TarefaCommands;
using ToDo.Domain.Commands.UsuarioCommands;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TarefaService(ITarefaRepository repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> AddAsync(TarefaViewModel tarefaViewModel)
        {
            var addTaskCommand = _mapper.Map<AddTaskCommand>(tarefaViewModel);
            return await _mediator.Send(addTaskCommand);
        }

        public async Task<bool> DeleteAsync(Guid taskId)
        {
            return await _mediator.Send(new DeleteTaskCommand(taskId));
        }
        public async Task<bool> UpdateAsync(TarefaViewModel tarefaViewModel)
        {
            var editTaskCommand = _mapper.Map<EditTaskCommand>(tarefaViewModel);
            return await _mediator.Send(editTaskCommand);
        }

        public async Task<IEnumerable<TarefaViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TarefaViewModel>>(await _repository.GetAllAsync());  
        }

        public async Task<TarefaViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<TarefaViewModel>(await _repository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<TarefaViewModel>> GetByStatusAsync(StatusTarefa statusTarefa)
        {
            return _mapper.Map<IEnumerable<TarefaViewModel>>(await _repository.GetByStatusAsync(statusTarefa));
        }
    }
}
