using System.ComponentModel;
using ToDo.Domain.Enums;

namespace ToDo.Application.ViewModels
{
    public class TarefaViewModel
    {
        public Guid TaskID { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }
        public Guid ResponsableID { get; set; }

        [DisplayName("Data prevista")]
        public DateTime EstimatedDate { get; set; }

        [DisplayName("Status")]
        public StatusTarefa TaskStatus { get; set; }

        [DisplayName("Responsável")]
        public string ResponsableName { get; set; }

    }
}
