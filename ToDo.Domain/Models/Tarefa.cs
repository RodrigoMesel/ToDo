using ToDo.Domain.Core.Models;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Models
{
    public class Tarefa : Entity
    {
        public string Descricao { get; private set; }

        public Guid IdResponsavel { get; set; }

        public virtual Usuario Responsavel { get; private set; }

        public DateTime DataPrevista { get; private set; }

        public StatusTarefa StatusTarefa { get; private set; }

        public Tarefa(Guid id, string descricao, Guid idResponsavel, DateTime dataPrevista, StatusTarefa statusTarefa) : base(id)
        {
            Descricao = descricao;
            IdResponsavel = idResponsavel;
            DataPrevista = dataPrevista;
            StatusTarefa = statusTarefa;
        }

        public Tarefa()
        {
        }
    }
}
