using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Infra.Data.Repository;
using CondominioAppPreCadastro.App.Aplication.Commands;
using CondominioAppPreCadastro.App.Aplication.Events;
using CondominioAppPreCadastro.App.Aplication.Query;
using CondominioAppPreCadastro.App.Data.Repository;
using CondominioAppPreCadastro.App.Models;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioApp.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Condominio
            services.AddScoped<IRequestHandler<CadastrarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarConfiguracaoCondominioCommand, ValidationResult>, CondominioCommandHandler>();


            //Grupo
            services.AddScoped<IRequestHandler<CadastrarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarGrupoCommand, ValidationResult>, GrupoCommandHandler>();


            //Unidades
            services.AddScoped<IRequestHandler<CadastrarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();

            //Pre Cadastro
            services.AddScoped<IRequestHandler<InserirNovoLeadCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<INotificationHandler<LeadCadastradoEvent>, LeadEventHandler>();

            //Query
            services.AddScoped<IQueryLead, QueryLead>();

            //Repositórios
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
        }
    }
}