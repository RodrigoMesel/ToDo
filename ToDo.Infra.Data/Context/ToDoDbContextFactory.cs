using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Infra.Data.Context
{
    public class ToDoDbContextFactory : IDesignTimeDbContextFactory<ToDoDbContext>
    {
        public ToDoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ToDoDbContext>();
            optionsBuilder.UseNpgsql();

            return new ToDoDbContext(optionsBuilder.Options);
        }
    }
}
