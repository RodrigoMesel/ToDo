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

            CreateMap<Tarefa, TarefaViewModel>().ConstructUsing(x => new TarefaViewModel
            {
                TaskID = x.Id,
                Description = x.Descricao,
                ResponsableID = x.IdResponsavel,
                EstimatedDate = x.DataPrevista,
                TaskStatus = x.StatusTarefa,
                ResponsableName = x.Responsavel.Name
            });
        }
    }
}
