using CondominioApp.Core.Mediator;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Usuario;
using CondominioApp.NotificacaoEmail.Aplication.Events;
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

            #region Usuario
            services.AddScoped<IRequestHandler<CadastrarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarUltimoLoginUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            #endregion

            #region Morador
            services.AddScoped<IRequestHandler<CadastrarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<INotificationHandler<MoradorCadastradoEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MoradorApagadoEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MoradorRemovidoEvent>, MoradorEventHandler>();
            #endregion

            #region Funcionario
            services.AddScoped<IRequestHandler<CadastrarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddScoped<INotificationHandler<FuncionarioCadastradoEvent>, FuncionarioEventHandler>();
            #endregion

            #region NotificacaoEmail -Contexto            
            services.AddScoped<INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent>, NotificacaoEmailIdentidadeApiEventHandler>();
            services.AddScoped<INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent>, NotificacaoEmailIdentidadeApiEventHandler>();
            #endregion


            #region Queries
            services.AddScoped<IUsuarioQuery, UsuarioQuery>();
            services.AddScoped<IPrincipalQuery, PrincipalQuery>();
            #endregion

            #region Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPrincipalRepository, PrincipalRepository>();
            #endregion          

            #region Query Repositories            
            services.AddScoped<IMoradorQueryRepository, MoradorQueryRepository>();
            services.AddScoped<IFuncionarioQueryRepository, FuncionarioQueryRepository>();
            services.AddScoped<IVeiculoQueryRepository, VeiculoQueryRepository>();
            services.AddScoped<IPrincipalQueryRepository, PrincipalQueryRepository>();
            #endregion

            //services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
    }
}