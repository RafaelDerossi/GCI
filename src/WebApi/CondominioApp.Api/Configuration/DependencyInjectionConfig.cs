using CondominioApp.BS.App.Services;
using CondominioApp.BS.App.Services.Interfaces;
using CondominioApp.Core.Mediator;
using CondominioApp.Correspondencias.App.Aplication.Commands;
using CondominioApp.Correspondencias.App.Data.Repository;
using CondominioApp.Correspondencias.App.Models;
using CondominioApp.Correspondencias.App.Aplication.Query;
using CondominioApp.Enquetes.App.Aplication.Commands;
using CondominioApp.Enquetes.App.Aplication.Events;
using CondominioApp.Enquetes.App.Aplication.Query;
using CondominioApp.Enquetes.App.Data.Repository;
using CondominioApp.Enquetes.App.Models;
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
using CondominioApp.Comunicados.App.Aplication.Commands;
using CondominioApp.Comunicados.App.Models;
using CondominioApp.Comunicados.App.Data.Repository;
using CondominioApp.Comunicados.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Aplication.Commands;

namespace CondominioApp.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Condominio
            services.AddScoped<IRequestHandler<CadastrarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<EditarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<EditarConfiguracaoCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<INotificationHandler<CondominioCadastradoEvent>,CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioEditadoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioConfiguracaoEditadoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioRemovidoEvent>, CondominioEventHandler>();

            //Grupo
            services.AddScoped<IRequestHandler<CadastrarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<INotificationHandler<GrupoCadastradoEvent>, GrupoEventHandler>();
            services.AddScoped<INotificationHandler<GrupoEditadoEvent>, GrupoEventHandler>();
            services.AddScoped<INotificationHandler<GrupoRemovidoEvent>, GrupoEventHandler>();

            //Unidades
            services.AddScoped<IRequestHandler<CadastrarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<EditarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<INotificationHandler<UnidadeCadastradaEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeEditadaEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<CodigoUnidadeResetadoEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeRemovidaEvent>, UnidadeEventHandler>();

            //Enquete
            services.AddScoped<IRequestHandler<CadastrarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddScoped<IRequestHandler<EditarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddScoped<INotificationHandler<EnqueteCadastradaEvent>, EnqueteEventHandler>();

            //AlternativasEnquete
            services.AddScoped<IRequestHandler<EditarAlternativaCommand, ValidationResult>, AlternativaEnqueteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverAlternativaCommand, ValidationResult>, AlternativaEnqueteCommandHandler>();

            //RespostaEnquete
            services.AddScoped<IRequestHandler<CadastrarRespostaCommand, ValidationResult>, RespostaEnqueteCommandHandler>();


            //Correspondencia
            services.AddScoped<IRequestHandler<CadastrarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaVistaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaRetiradaCommand, ValidationResult>, CorrespondenciaCommandHandler>();            
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaDevolvidaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<DispararAlertaDeCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<GerarExcelCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();

            //Comunicado
            services.AddScoped<IRequestHandler<CadastrarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();

            //Reserva Area Comum
            services.AddScoped<IRequestHandler<CadastrarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();


            //Pre Cadastro
            services.AddScoped<IRequestHandler<InserirNovoLeadCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<IRequestHandler<TransferirCondominioCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<INotificationHandler<LeadCadastradoEvent>, LeadEventHandler>();
           

            //Query
            services.AddScoped<IQueryLead, QueryLead>();
            services.AddScoped<ICondominioQuery, CondominioQuery>();
            services.AddScoped<IEnqueteQuery, EnqueteQuery>();
            services.AddScoped<ICorrespondenciaQuery, CorrespondenciaQuery>();
            services.AddScoped<IComunicadoQuery, ComunicadoQuery>();

            //Repositórios
            services.AddScoped<ICondominioRepository, CondominioRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ICondominioQueryRepository, CondominioQueryRepository>();
            services.AddScoped<IEnqueteRepository, EnqueteRepository>();
            services.AddScoped<ICorrespondenciaRepository, CorrespondenciaRepository>();
            services.AddScoped<IComunidadoRepository, ComunicadoRepository>();
            services.AddScoped<IAreaComumRepository, AreaComumRepository>();

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