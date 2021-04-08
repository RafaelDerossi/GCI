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
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Aplication.Events;
using CondominioApp.ReservaAreaComum.Infra.Data.Repository;
using CondominioApp.Portaria.Aplication.Commands;
using CondominioApp.Portaria.Aplication.Events;
using CondominioApp.Portaria.Domain.Interfaces;
using CondominioApp.Portaria.Infra.Data.Repository;
using CondominioApp.Portaria.Infra.DataQuery.Repository;
using CondominioApp.Portaria.Aplication.Query;
using CondominioApp.Automacao.App.Aplication.Commands;
using CondominioApp.Automacao.App.Models;
using CondominioApp.Automacao.App.Data.Repository;
using CondominioApp.Automacao.App.Aplication.Query;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.Models;
using CondominioApp.Usuarios.App.Data.Repository;
using CondominioApp.Usuarios.App.Aplication.Events;
using CondominioApp.Usuarios.App.Aplication.Commands;
using CondominioApp.Automacao.App.Factory;
using CondominioApp.NotificacaoPush.App.Services.Interfaces;
using CondominioApp.NotificacaoPush.App.Services;
using CondominioApp.ArquivoDigital.App.Aplication.Commands;
using CondominioApp.ArquivoDigital.App.Models;
using CondominioApp.ArquivoDigital.App.Aplication.Query;
using CondominioApp.Ocorrencias.App.Aplication.Commands;
using CondominioApp.Ocorrencias.App.Data.Repository;
using CondominioApp.Ocorrencias.App.Models;
using CondominioApp.Ocorrencias.App.Aplication.Query;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.NotificacaoEmail.Aplication.Events;

namespace CondominioApp.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();


            #region ArquivoDigital -Contexto
            //Pasta
            services.AddScoped<IRequestHandler<CadastrarPastaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<EditarPastaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarPastaComoPublicaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarPastaComoPrivadaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverPastaCommand, ValidationResult>, PastaCommandHandler>();

            //Arquivo
            services.AddScoped<IRequestHandler<CadastrarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarPastaDoArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarArquivoComoPublicoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarArquivoComoPrivadoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverArquivoCommand, ValidationResult>, ArquivoCommandHandler>();

            #endregion


            #region Automacao -Contexto

            services.AddScoped<IDispositivosServiceFactory, DispositivoServiceFactory>();
            services.AddScoped<IRequestHandler<CadastrarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();
            services.AddScoped<IRequestHandler<EditarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();

            #endregion


            #region Base Software -Contexto

            //Base software
            services.AddScoped<IBoletoService, BoletoService>();

            #endregion


            #region Comunicado -Contexto

            //Comunicado
            services.AddScoped<IRequestHandler<CadastrarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();

            #endregion


            #region Correspondencia -Contexto

            //Correspondencia
            services.AddScoped<IRequestHandler<CadastrarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaVistaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaRetiradaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaDevolvidaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<DispararAlertaDeCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<GerarExcelCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();

            #endregion


            #region Enquete -Contexto

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

            #endregion
            

            #region Marketplace -Contexto

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

            #endregion


            #region NotificacaoEmail -Contexto            
            services.AddScoped<INotificationHandler<EnviarEmailComunicadoIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddScoped<INotificationHandler<EnviarEmailCorrespondenciaIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            #endregion


            #region NotificacaoPush -Contexto
            services.AddScoped<INotificacaoPushService, NotificacaoPushService>();
            services.AddScoped<INotificationHandler<EnviarPushParaSindicoIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddScoped<INotificationHandler<EnviarPushParaMoradorIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddScoped<INotificationHandler<EnviarPushParaUnidadeIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddScoped<INotificationHandler<EnviarPushParaUnidadesIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddScoped<INotificationHandler<EnviarPushParaCondominioIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddScoped<INotificationHandler<EnviarPushParaProprietariosIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddScoped<INotificationHandler<EnviarPushParaProprietariosPorUnidadeIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddScoped<INotificationHandler<EnviarPushParaTodosIntegrationEvent>, NotificacaoPushEventHandler>();
            #endregion


            #region Ocorrencia -Contexto
            //Ocorrencia
            services.AddScoped<IRequestHandler<CadastrarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<EditarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();

            //Resposta
            services.AddScoped<IRequestHandler<CadastrarRespostaOcorrenciaMoradorCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarRespostaOcorrenciaSindicoCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarRespostaOcorrenciaComoVistaCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<EditarRespostaOcorrenciaCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            #endregion


            #region Portaria -Contexto

            //Visitante                        
            services.AddScoped<IRequestHandler<CadastrarVisitantePorMoradorCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarVisitantePorPorteiroCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<EditarVisitantePorMoradorCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<EditarVisitantePorPorteiroCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverVisitanteCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<INotificationHandler<VisitanteCadastradoEvent>, VisitanteEventHandler>();
            services.AddScoped<INotificationHandler<VisitanteEditadoEvent>, VisitanteEventHandler>();
            services.AddScoped<INotificationHandler<VisitanteRemovidoEvent>, VisitanteEventHandler>();

            //Visita
            services.AddScoped<IRequestHandler<CadastrarVisitaPorPorteiroCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarVisitaPorMoradorCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<EditarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<AprovarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<ReprovarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<IniciarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<TerminarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<INotificationHandler<VisitaCadastradaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaEditadaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaRemovidaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaAprovadaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaReprovadaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaIniciadaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaTerminadaEvent>, VisitaEventHandler>();

            #endregion
            

            #region Pre-Cadastro -Contexto

            //Pre Cadastro
            services.AddScoped<IRequestHandler<InserirNovoLeadCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<IRequestHandler<TransferirCondominioCommand, ValidationResult>, LeadCommandHandler>();
            services.AddScoped<INotificationHandler<LeadCadastradoEvent>, LeadEventHandler>();

            #endregion


            #region Principal -Contexto

            //Condominio
            services.AddScoped<IRequestHandler<CadastrarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<EditarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<EditarConfiguracaoCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<INotificationHandler<CondominioCadastradoEvent>, CondominioEventHandler>();
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

            //Contratos
            services.AddScoped<IRequestHandler<CadastrarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            services.AddScoped<IRequestHandler<EditarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverContratoCommand, ValidationResult>, ContratoCommandHandler>();
            services.AddScoped<INotificationHandler<ContratoCadastradoEvent>, ContratoEventHandler>();
            services.AddScoped<INotificationHandler<ContratoEditadoEvent>, ContratoEventHandler>();
            services.AddScoped<INotificationHandler<ContratoRemovidoEvent>, ContratoEventHandler>();

            #endregion


            #region ReservaAreaComum -Contexto

            //Area Comum
            services.AddScoped<IRequestHandler<CadastrarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<EditarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<DesativarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<INotificationHandler<AreaComumCadastradaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumEditadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumAtivadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumDesativadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumRemovidaEvent>, AreaComumEventHandler>();

            //Reserva
            services.AddScoped<IRequestHandler<CadastrarReservaCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<AprovarReservaCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarReservaComoUsuarioCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarReservaComoAdministradorCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<RetirarReservaDaFilaCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<INotificationHandler<ReservaCadastradaEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaAprovadaEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaCanceladaEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaRetiradaDaFilaEvent>, ReservaEventHandler>();

            #endregion


            #region Usuarios -Context
            //Morador
            services.AddScoped<IRequestHandler<CadastrarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarComoUnidadePrincipalCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarComoProprietarioCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<DesmarcarComoProprietarioCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<INotificationHandler<MoradorCadastradoEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeMarcadaComoPrincipalEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MarcadoComoProprietarioEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<DesmarcadoComoProprietarioEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MoradorExcluidoEvent>, MoradorEventHandler>();

            //Funcionario
            services.AddScoped<IRequestHandler<CadastrarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddScoped<INotificationHandler<FuncionarioCadastradoEvent>, FuncionarioEventHandler>();
            services.AddScoped<IRequestHandler<EditarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddScoped<INotificationHandler<FuncionarioEditadoEvent>, FuncionarioEventHandler>();

            //Usuario
            services.AddScoped<IRequestHandler<CadastrarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<EditarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<INotificationHandler<UsuarioEditadoEvent>, UsuarioEventHandler>();

            //Veiculo
            services.AddScoped<IRequestHandler<CadastrarVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddScoped<INotificationHandler<VeiculoCadastradoEvent>, VeiculoEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioDoVeiculoNoCondominioEditadoEvent>, VeiculoEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoRemovidoEvent>, VeiculoEventHandler>();

            //Mobile
            services.AddScoped<IRequestHandler<RegistrarMoradorMobileCommand, ValidationResult>, MobileCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarFuncionarioMobileCommand, ValidationResult>, MobileCommandHandler>();

            #endregion





            #region Querys

            //Query
            services.AddScoped<IArquivoDigitalQuery, ArquivoDigitalQuery>();
            services.AddScoped<IAutomacaoQuery, AutomacaoQuery>();
            services.AddScoped<IComunicadoQuery, ComunicadoQuery>();
            services.AddScoped<ICorrespondenciaQuery, CorrespondenciaQuery>();
            services.AddScoped<IEnqueteQuery, EnqueteQuery>();
            services.AddScoped<IOcorrenciaQuery, OcorrenciaQuery>();
            services.AddScoped<IPortariaQuery, PortariaQuery>();
            services.AddScoped<IPrincipalQuery, PrincipalQuery>();
            services.AddScoped<IQueryLead, QueryLead>();
            services.AddScoped<IReservaAreaComumQuery, ReservaAreaComumQuery>();            
            services.AddScoped<IUsuarioQuery, UsuarioQuery>();
            //services.AddScoped<IOcorrenciaQuery, OcorrenciaQuery>();
            #endregion

            #region Repositórios
            //Repositórios
            services.AddScoped<IArquivoDigitalRepository, ArquivoDigitalRepository>();
            services.AddScoped<IAutomacaoRepository, AutomacaoRepository>();
            services.AddScoped<IComunidadoRepository, ComunicadoRepository>();
            services.AddScoped<ICorrespondenciaRepository, CorrespondenciaRepository>();
            services.AddScoped<IEnqueteRepository, EnqueteRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IPortariaRepository, PortariaRepository>();
            services.AddScoped<IPrincipalRepository, PrincipalRepository>();            
            services.AddScoped<IReservaAreaComumRepository, ReservaAreaComumRepository>();            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
            #endregion

            #region Repositórios Query
            //Repositórios Query                     
            services.AddScoped<IFuncionarioQueryRepository, FuncionarioQueryRepository>();
            services.AddScoped<IMoradorQueryRepository, MoradorQueryRepository>();
            services.AddScoped<IPortariaQueryRepository, PortariaQueryRepository>();
            services.AddScoped<IPrincipalQueryRepository, PrincipalQueryRepository>();                        
            services.AddScoped<IReservaAreaComumQueryRepository, ReservaAreaComumQueryRepository>();            
            services.AddScoped<IVeiculoQueryRepository, VeiculoQueryRepository>();           
            
            #endregion

        }
    }
}
