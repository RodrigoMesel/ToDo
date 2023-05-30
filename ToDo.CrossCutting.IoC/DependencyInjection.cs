using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Context;
using ToDo.Infra.Data.Repository;

namespace ToDo.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ToDoDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
