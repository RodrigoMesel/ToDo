using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ToDoDbContext db) : base(db)
        {
        }
    }
}
