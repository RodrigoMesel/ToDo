using AutoMapper;
using ToDo.Application.ViewModels;
using ToDo.Domain.Commands.UsuarioCommands;

namespace ToDo.Application.Mapper
{
    public class ViewModelToDomainMap : Profile
    {
        public ViewModelToDomainMap() 
        {
            CreateMap<UsuarioViewModel, AddUserCommand>().ConstructUsing(x => new AddUserCommand(x.Name));
            CreateMap<UsuarioViewModel, EditUserCommand>().ConstructUsing(x => new EditUserCommand(x.UserId, x.Name));
        }
    }
}
