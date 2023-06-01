using ToDo.Domain.Enums;

namespace ToDo.Application.ViewModels
{
    public class TarefaViewModel
    {
        public Guid TaskID { get; set; }
        public string Description { get; set; }
        public Guid ResponsableID { get; set; }
        public DateTime EstimatedDate { get; set; }
        public StatusTarefa TaskStatus { get; set; }

    }
}
