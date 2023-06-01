using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Commands.TarefaCommands
{
    public class EditTaskCommand : TaskCommand
    {
        public EditTaskCommand(Guid id, string descricao, Guid idResponsavel, DateTime dataPrevista, StatusTarefa statusTarefa) 
        {
            Id = id;
            Descricao = descricao;
            IdResponsavel = idResponsavel;
            DataPrevista = dataPrevista;
            StatusTarefa = statusTarefa;
        }
    }
}
