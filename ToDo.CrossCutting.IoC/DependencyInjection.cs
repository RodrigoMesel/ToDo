using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDo.Application.Interfaces;
using ToDo.Application.Mapper;
using ToDo.Application.Services;
using ToDo.Domain.Commands.TarefaCommands;
using ToDo.Domain.Commands.UsuarioCommands;
using ToDo.Domain.Core.Interfaces;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Context;
using ToDo.Infra.Data.Repository;
using ToDo.Infra.Data.UoW;

namespace ToDo.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //AutoMapper
            services.AddAutoMapper(typeof(DomainToViewModelMap), typeof(ViewModelToDomainMap));

            //Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //Database
            services.AddScoped<ToDoDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITarefaService, TarefaService>();

            //CommandHandlers
            services.AddScoped<IRequestHandler<AddUserCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<EditUserCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, ValidationResult>, UsuarioCommandHandler>();

            services.AddScoped<IRequestHandler<AddTaskCommand, bool>, TaskCommandHandler>();
            services.AddScoped<IRequestHandler<EditTaskCommand, bool>, TaskCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTaskCommand, bool>, TaskCommandHandler>();

        }

    }
}
