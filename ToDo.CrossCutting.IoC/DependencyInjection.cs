using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDo.Application.Interfaces;
using ToDo.Application.Mapper;
using ToDo.Application.Services;
using ToDo.Domain.Commands.UsuarioCommands;
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

            //AutoMapper
            services.AddAutoMapper(typeof(DomainToViewModelMap), typeof(ViewModelToDomainMap));

            //Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //Database
            services.AddDbContext<ToDoDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();

            //CommandHandlers
            services.AddScoped<IRequestHandler<AddUserCommand, bool>, UsuarioCommandHanler>();
            services.AddScoped<IRequestHandler<EditUserCommand, bool>, UsuarioCommandHanler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, UsuarioCommandHanler>();

        }
    }
}
