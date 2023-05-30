using AutoMapper;
using MediatR;
using ToDo.Application.Interfaces;
using ToDo.Application.ViewModels;
using ToDo.Domain.Commands.UsuarioCommands;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            return await _mediator.Send(new DeleteUserCommand(userId));
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _repository.GetAllAsync());
        }

        public async Task<UsuarioViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _repository.GetByIdAsync(id));
        }

        async Task<bool> IUsuarioService.AddAsync(UsuarioViewModel usuarioViewModel)
        {
            var addUserCommand = _mapper.Map<AddUserCommand>(usuarioViewModel);
            return await _mediator.Send(addUserCommand);
        }

        async Task<bool> IUsuarioService.UpdateAsync(UsuarioViewModel usuarioViewModel)
        {
            var editUserCommand = _mapper.Map<EditUserCommand>(usuarioViewModel);
            return await _mediator.Send(editUserCommand);
        }
    }
}
