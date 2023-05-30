namespace ToDo.Domain.Core.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity(Guid id)
        {
            Id = id;
        }

        public Entity()
        {
        }
    }
}
