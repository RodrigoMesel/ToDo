using ToDo.Domain.Core.Interfaces;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ToDoDbContext _context;

        public UnitOfWork(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
