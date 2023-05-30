using ToDo.Domain.Core.Models;

namespace ToDo.Domain.Models
{
    public class Usuario : Entity
    {
        public string Name { get; private set; }

        public virtual IQueryable<Tarefa> Tarefas { get; set; }

        public Usuario(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public Usuario()
        {
        }
    }
}
