using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.ViewModels;
using ToDo.Domain.Models;

namespace ToDo.Application.Mapper
{
    public class DomainToViewModelMap : Profile
    {
        public DomainToViewModelMap() 
        {
            CreateMap<Usuario, UsuarioViewModel>().ConstructUsing(x => new UsuarioViewModel
            {
                UserId = x.Id,
                Name = x.Name
            });
        }
    }
}
