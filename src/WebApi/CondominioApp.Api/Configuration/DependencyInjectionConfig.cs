﻿using CondominioApp.BS.App.Services;
using CondominioApp.BS.App.Services.Interfaces;
using CondominioApp.Core.Mediator;
using CondominioApp.Principal.Aplication.Commands;
using CondominioApp.Principal.Aplication.Events;
using CondominioApp.Principal.Aplication.Query;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.Principal.Infra.Data.Repository;
using CondominioAppMarketplace.App;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.Domain.Interfaces;
using CondominioAppMarketplace.Infra.Repositories;
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
            services.AddScoped<IRequestHandler<RemoverCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<INotificationHandler<CondominioCadastradoEvent>,CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioAlteradoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioConfiguracaoAlteradoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioRemovidoEvent>, CondominioEventHandler>();

            //Grupo
            services.AddScoped<IRequestHandler<CadastrarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<INotificationHandler<GrupoCadastradoEvent>, GrupoEventHandler>();
            services.AddScoped<INotificationHandler<GrupoAlteradoEvent>, GrupoEventHandler>();
            services.AddScoped<INotificationHandler<GrupoRemovidoEvent>, GrupoEventHandler>();

            //Unidades
            services.AddScoped<IRequestHandler<CadastrarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<INotificationHandler<UnidadeCadastradaEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeAlteradaEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<CodigoUnidadeResetadoEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeRemovidaEvent>, UnidadeEventHandler>();

            //Pre Cadastro
            services.AddScoped<IRequestHandler<InserirNovoLeadCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<IRequestHandler<TransferirCondominioCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<INotificationHandler<LeadCadastradoEvent>, LeadEventHandler>();

            //Query
            services.AddScoped<IQueryLead, QueryLead>();
            services.AddScoped<ICondominioQuery, CondominioQuery>();

            //Repositórios
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ICondominioQueryRepository, CondominioQueryRepository>();

            //Base software
            services.AddScoped<IBoletoService, BoletoService>();



            //Marketplace

            //Parceiro
            services.AddScoped<IAppServiceParceiro, AppServiceParceiro>();
            services.AddScoped<IParceiroRepository, ParceiroRepository>();

            //Item de venda
            services.AddScoped<IAppServiceItemDeVenda, AppServiceItemDeVenda>();
            services.AddScoped<IItemDeVendaRepository, ItemDeVendaRepository>();

            //Produto
            services.AddScoped<IAppServiceProduto, AppServiceProduto>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Campanha
            services.AddScoped<IAppServiceCampanha, AppServiceCampanha>();
            services.AddScoped<ICampanhaRepository, CampanhaRepository>();

            //Lead
            services.AddScoped<IAppServiceLead, AppServiceLead>();

        }
    }
}