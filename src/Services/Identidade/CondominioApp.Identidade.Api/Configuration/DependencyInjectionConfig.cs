using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Query;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Infra.Data.Repository;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.Data.Repository;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioApp.Identidade.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            #region Morador
            services.AddScoped<IRequestHandler<CadastrarMoradorCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<INotificationHandler<MoradorCadastradoEvent>, UsuarioEventHandler>();
            #endregion

            #region Funcionario
            services.AddScoped<IRequestHandler<CadastrarFuncionarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<INotificationHandler<FuncionarioCadastradoEvent>, UsuarioEventHandler>();
            #endregion



            #region Queries
            services.AddScoped<IUsuarioQuery, UsuarioQuery>();
            services.AddScoped<ICondominioQuery, CondominioQuery>();
            #endregion

            #region Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            #endregion          

            #region Query Repositories            
            services.AddScoped<IMoradorQueryRepository, MoradorQueryRepository>();
            services.AddScoped<IFuncionarioQueryRepository, FuncionarioQueryRepository>();
            services.AddScoped<IVeiculoQueryRepository, VeiculoQueryRepository>();
            services.AddScoped<ICondominioQueryRepository, CondominioQueryRepository>();
            #endregion

            //services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
    }
}