using AutoMapper;
using ToDo.Application.ViewModels;
using ToDo.Domain.Commands.TarefaCommands;
using ToDo.Domain.Commands.UsuarioCommands;

namespace ToDo.Application.Mapper
{
    public class ViewModelToDomainMap : Profile
    {
        public ViewModelToDomainMap() 
        {
            CreateMap<UsuarioViewModel, AddUserCommand>().ConstructUsing(x => new AddUserCommand(x.Name));
            CreateMap<UsuarioViewModel, EditUserCommand>().ConstructUsing(x => new EditUserCommand(x.UserId, x.Name));

            CreateMap<TarefaViewModel, AddTaskCommand>().ConstructUsing(x => new AddTaskCommand(
                x.Description,
                x.ResponsableID,
                x.EstimatedDate,
                x.TaskStatus)) ;

            CreateMap<TarefaViewModel, EditTaskCommand>().ConstructUsing(x => new EditTaskCommand(
                x.TaskID,
                x.Description,
                x.ResponsableID,
                x.EstimatedDate,
                x.TaskStatus));
        }
    }
}
