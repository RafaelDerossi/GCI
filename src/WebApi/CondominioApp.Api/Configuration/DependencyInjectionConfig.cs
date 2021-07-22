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
using CondominioApp.NotificacaoEmail.Aplication.Events;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Comunicado;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Correspondencia;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Enquete;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Ocorrencia;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents;
using CondominioApp.Core.Data;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Reserva;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasParaAdministrador;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasDeMorador;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.RegrasGerais;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCriacaoDeReserva.Regras;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaMorador;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.RegrasParaAdministracao;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy.RegrasParaCancelamento.Regras;
using CondominioApp.NotificacaoPush.App.Events;
using CondominioApp.NotificacaoPush.App.Aplication.Commands;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Models;
using CondominioApp.ArquivoDigital.AzureStorageBlob.Services;
using CondominioApp.Correspondencias.Aplication.Events;

namespace CondominioApp.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();            
            

            #region ArquivoDigital -Contexto
            //Pasta
            services.AddScoped<IRequestHandler<AdicionarPastaRaizCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarSubPastaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarPastaDeSistemaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarPastaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarPastaComoPublicaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarPastaComoPrivadaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarPastaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<MoverPastaParaRaizCommand, ValidationResult>, PastaCommandHandler>();
            services.AddScoped<IRequestHandler<MoverSubPastaCommand, ValidationResult>, PastaCommandHandler>();

            //Arquivo
            services.AddScoped<IAzureStorage, AzureStorage>();
            services.AddScoped<IAzureStorageService, AzureStorageService>();
            services.AddScoped<IRequestHandler<AdicionarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarPastaDoArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarArquivoComoPublicoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarArquivoComoPrivadoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();

            #endregion


            #region Automacao -Contexto

            services.AddScoped<IDispositivosServiceFactory, DispositivoServiceFactory>();
            services.AddScoped<IRequestHandler<AdicionarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();

            services.AddScoped<IRequestHandler<AdicionarDispositivoWebhookCommand, ValidationResult>, DispositivoWebhookCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarDispositivoWebhookCommand, ValidationResult>, DispositivoWebhookCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarDispositivoWebhookCommand, ValidationResult>, DispositivoWebhookCommandHandler>();
            services.AddScoped<IRequestHandler<LigarDesligarDispositivoWebhookCommand, ValidationResult>, DispositivoWebhookCommandHandler>();

            #endregion


            #region Base Software -Contexto

            //Base software
            services.AddScoped<IBoletoService, BoletoService>();

            #endregion


            #region Comunicado -Contexto

            //Comunicado
            services.AddScoped<IRequestHandler<AdicionarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();

            #endregion


            #region Correspondencia -Contexto

            //Correspondencia
            services.AddScoped<IRequestHandler<AdicionarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaVistaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaRetiradaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarCorrespondenciaDevolvidaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<DispararAlertaDeCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<IRequestHandler<GerarExcelCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddScoped<INotificationHandler<RegistraHistoricoEvent>, HistoricoEventHandler>();
            services.AddScoped<INotificationHandler<MarcarComoVistoEvent>, HistoricoEventHandler>();
            #endregion


            #region Enquete -Contexto

            //Enquete
            services.AddScoped<IRequestHandler<AdicionarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarDataFimDaEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddScoped<INotificationHandler<EnqueteCadastradaEvent>, EnqueteEventHandler>();

            //AlternativasEnquete
            services.AddScoped<IRequestHandler<AtualizarAlternativaCommand, ValidationResult>, AlternativaEnqueteCommandHandler>();
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
            services.AddScoped<INotificationHandler<EnviarEmailEnqueteIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddScoped<INotificationHandler<EnviarEmailOcorrenciaIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddScoped<INotificationHandler<EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddScoped<INotificationHandler<EnviarEmailRespostaOcorrenciaParaAdministracaoIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddScoped<INotificationHandler<EnviarEmailReservaParaMoradorIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddScoped<INotificationHandler<EnviarEmailReservaParaAdministracaoIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            #endregion


            #region NotificacaoPush -Contexto
            services.AddScoped<IRequestHandler<EnviarNotificacaoParaTodosNoCondominioCommand, ValidationResult>, NotificacaoPushCommandHandler>();
            services.AddScoped<INotificacaoPushService, NotificacaoPushService>();
            services.AddScoped<INotificationHandler<EnviarPushParaAdministracaoIntegrationEvent>, NotificacaoPushEventHandler>();
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
            services.AddScoped<IRequestHandler<AdicionarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();

            //Resposta
            services.AddScoped<IRequestHandler<AdicionarRespostaOcorrenciaMoradorCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarRespostaOcorrenciaAdministracaoCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarRespostaOcorrenciaComoVistaCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarRespostaOcorrenciaCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            #endregion


            #region Portaria -Contexto

            //Visitante                        
            services.AddScoped<IRequestHandler<AdicionarVisitantePorMoradorCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarVisitantePorPorteiroCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarVisitantePorMoradorCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarVisitantePorPorteiroCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarVisitanteCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddScoped<INotificationHandler<VisitanteAdicionadoEvent>, VisitanteEventHandler>();
            services.AddScoped<INotificationHandler<VisitanteAtualizadoEvent>, VisitanteEventHandler>();
            services.AddScoped<INotificationHandler<VisitanteApagadoEvent>, VisitanteEventHandler>();

            //Visita
            services.AddScoped<IRequestHandler<AdicionarVisitaPorPorteiroCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarVisitaPorMoradorCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<AprovarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<ReprovarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<IniciarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<IRequestHandler<TerminarVisitaCommand, ValidationResult>, VisitaCommandHandler>();
            services.AddScoped<INotificationHandler<VisitaAdicionadaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaAtualizadaEvent>, VisitaEventHandler>();
            services.AddScoped<INotificationHandler<VisitaApagadaEvent>, VisitaEventHandler>();
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
            services.AddScoped<IRequestHandler<AdicionarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarConfiguracaoCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<IRequestHandler<DefinirSindicoDoCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddScoped<INotificationHandler<CondominioCadastradoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioEditadoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioConfiguracaoEditadoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<CondominioApagadoEvent>, CondominioEventHandler>();
            services.AddScoped<INotificationHandler<SindicoDoCondominioDefinidoEvent>, CondominioEventHandler>();


            //Grupo
            services.AddScoped<IRequestHandler<AdicionarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddScoped<INotificationHandler<GrupoCadastradoEvent>, GrupoEventHandler>();
            services.AddScoped<INotificationHandler<GrupoEditadoEvent>, GrupoEventHandler>();
            services.AddScoped<INotificationHandler<GrupoApagadoEvent>, GrupoEventHandler>();

            //Unidades
            services.AddScoped<IRequestHandler<AdicionarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarVagasDaUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddScoped<INotificationHandler<UnidadeCadastradaEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeEditadaEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<CodigoUnidadeResetadoEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeRemovidaEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<VagaDeUnidadeEditadaEvent>, UnidadeEventHandler>();

            //Contratos
            services.AddScoped<IRequestHandler<AdicionarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            

            #endregion


            #region ReservaAreaComum -Contexto

            //Area Comum
            services.AddScoped<IRequestHandler<AdicionarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<DesativarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarArquivoAnexoDaAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarFotoDeAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverFotoDaAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddScoped<INotificationHandler<AreaComumAdicionadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumAtualizadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumAtivadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumDesativadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<AreaComumApagadaEvent>, AreaComumEventHandler>();
            services.AddScoped<INotificationHandler<ArquivoAnexoDaAreaComumAtualizadoEvent>, AreaComumEventHandler>();

            //Reserva
            services.AddScoped<IRequestHandler<SolicitarReservaComoMoradorCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<SolicitarReservaComoAdministradorCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<AprovarReservaAutomaticamenteCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<AprovarReservaPelaAdministracaoCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<AguardarAprovacaoDaReservaPelaAdmCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<ReprovarReservaAutomaticamenteCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<ReprovarReservaPelaAdmCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<EnviarReservaParaFilaCommand, ValidationResult>, ReservaCommandHandler>();            
            services.AddScoped<IRequestHandler<CancelarReservaComoUsuarioCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarReservaComoAdministradorCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<RetirarReservaDaFilaCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarReservaComoExpiradaCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddScoped<INotificationHandler<ReservaSolicitadaComoUsuarioEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaSolicitadaComoAdministradorEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaAprovadaAutomaticamenteEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaAprovadaPelaAdministracaoEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaEnviadaParaAguardarAprovacaoEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaReprovadaAutomaticamenteEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaReprovadaPelaAdmEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaEnviadaParaFilaEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaCanceladaPeloUsuarioEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaCanceladaPelaAdmEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaRetiradaDaFilaEvent>, ReservaEventHandler>();
            services.AddScoped<INotificationHandler<ReservaMarcadaComoExpiradaEvent>, ReservaEventHandler>();

            //Regras de Reserva
            services.AddScoped<IReservaStrategy, ReservaStrategy>();
            services.AddScoped<IRegrasDeCriacaoDeReserva, RegrasDeCriacaoDeReserva>();
            services.AddScoped<IRegrasDeAdministradorParaReservar, RegrasDeAdministradorParaReservar>();
            services.AddScoped<IRegrasDeMoradorParaReservar, RegrasDeMoradorParaReservar>();
            services.AddScoped<IRegrasGeraisParaReservar, RegrasGeraisParaReservar>();
            services.AddScoped<IRegraAntecedenciaMaxima, RegraAntecedenciaMaxima>();
            services.AddScoped<IRegraAntecedenciaMinima, RegraAntecedenciaMinima>();
            services.AddScoped<IRegraBloqueioDaAreaComum, RegraBloqueioDaAreaComum>();
            services.AddScoped<IRegraDataRetroativaNaoPermitida, RegraDataRetroativaNaoPermitida>();
            services.AddScoped<IRegraDataRetroativaPermitida, RegraDataRetroativaPermitida>();
            services.AddScoped<IRegraDiasPermitidos, RegraDiasPermitidos>();
            services.AddScoped<IRegraDuracaoLimite, RegraDuracaoLimite>();
            services.AddScoped<IRegraHorarioDentroDosLimites, RegraHorarioDentroDosLimites>();
            services.AddScoped<IRegraHorarioDisponivelComSobreposicao, RegraHorarioDisponivelComSobreposicao>();
            services.AddScoped<IRegraHorarioDisponivelSemSobreposicao, RegraHorarioDisponivelSemSobreposicao>();
            services.AddScoped<IRegraIntervaloParaMesmaUnidade, RegraIntervaloParaMesmaUnidade>();
            services.AddScoped<IRegraIntervalosFixos, RegraIntervalosFixos>();
            services.AddScoped<IRegraLimitePorUnidadePorDia, RegraLimitePorUnidadePorDia>();

            services.AddScoped<IRegrasDeCancelamentoDeReserva, RegrasDeCancelamentoDeReserva>();
            services.AddScoped<IRegrasDeCancelamentoDeReservaPeloMorador, RegrasDeCancelamentoDeReservaPeloMorador>();
            services.AddScoped<IRegrasDeCancelamentoDeReservaPelaAdministracao, RegrasDeCancelamentoDeReservaPelaAdministracao>();
            services.AddScoped<IRegraDoPrazoMinimoPraCancelar, RegraDoPrazoMinimoPraCancelar>();
            services.AddScoped<IRegraDoStatusPraCancelar, RegraDoStatusPraCancelar>();

            #endregion


            #region Usuarios -Context
            //Morador
            services.AddScoped<IRequestHandler<AdicionarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarComoUnidadePrincipalCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<MarcarComoProprietarioCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<DesmarcarComoProprietarioCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<IRequestHandler<DesativarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddScoped<INotificationHandler<MoradorAdicionadoEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeMarcadaComoPrincipalEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MarcadoComoProprietarioEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<DesmarcadoComoProprietarioEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MoradorRemovidoEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MoradorApagadoEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MoradorAtivadoEvent>, MoradorEventHandler>();
            services.AddScoped<INotificationHandler<MoradorDesativadoEvent>, MoradorEventHandler>();

            //Funcionario
            services.AddScoped<IRequestHandler<AdicionarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();            
            services.AddScoped<IRequestHandler<AtualizarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddScoped<IRequestHandler<DesativarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddScoped<INotificationHandler<FuncionarioAdicionadoEvent>, FuncionarioEventHandler>();
            services.AddScoped<INotificationHandler<FuncionarioAtualizadoEvent>, FuncionarioEventHandler>();
            services.AddScoped<INotificationHandler<FuncionarioAtivadoEvent>, FuncionarioEventHandler>();
            services.AddScoped<INotificationHandler<FuncionarioDesativadoEvent>, FuncionarioEventHandler>();

            //Usuario
            services.AddScoped<IRequestHandler<AdicionarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarUltimoLoginUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<INotificationHandler<UsuarioEditadoEvent>, UsuarioEventHandler>();            

            //Veiculo
            services.AddScoped<IRequestHandler<AdicionarVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<ApagarVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();            
            services.AddScoped<INotificationHandler<VeiculoCadastradoEvent>, VeiculoEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioDoVeiculoNoCondominioEditadoEvent>, VeiculoEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoRemovidoEvent>, VeiculoEventHandler>();
            services.AddScoped<INotificationHandler<VeiculoEditadoEvent>, VeiculoEventHandler>();
            
            //Mobile
            services.AddScoped<IRequestHandler<RegistrarMoradorMobileCommand, ValidationResult>, MobileCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarFuncionarioMobileCommand, ValidationResult>, MobileCommandHandler>();

            #endregion





            #region Querys     
            services.AddScoped<IArquivoDigitalQuery, ArquivoDigitalQuery>();
            services.AddScoped<IAutomacaoQuery, AutomacaoQuery>();
            services.AddScoped<IComunicadoQuery, ComunicadoQuery>();
            services.AddScoped<ICorrespondenciaQuery, CorrespondenciaQuery>();
            services.AddScoped<IEnqueteQuery, EnqueteQuery>();
            services.AddScoped<IOcorrenciaQuery, OcorrenciaQuery>();
            services.AddScoped<IPortariaQuery, PortariaQuery>();
            services.AddScoped<IPrincipalQuery, PrincipalQuery>();
            services.AddScoped<IReservaAreaComumQuery, ReservaAreaComumQuery>();
            services.AddScoped<IQueryLead, QueryLead>();
            services.AddScoped<IUsuarioQuery, UsuarioQuery>();
            #endregion


            #region Repositórios            
            services.AddScoped<IArquivoDigitalRepository, ArquivoDigitalRepository>();
            services.AddScoped<IAutomacaoRepository, AutomacaoRepository>();
            services.AddScoped<IComunidadoRepository, ComunicadoRepository>();
            services.AddScoped<ICorrespondenciaRepository, CorrespondenciaRepository>();
            services.AddScoped<IEnqueteRepository, EnqueteRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
            services.AddScoped<IPortariaRepository, PortariaRepository>();
            services.AddScoped<IPrincipalRepository, PrincipalRepository>();            
            services.AddScoped<IReservaAreaComumRepository, ReservaAreaComumRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

            #region Repositórios Query               
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
