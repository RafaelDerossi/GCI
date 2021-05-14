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

namespace CondominioApp.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddSingleton<IMediatorHandler, MediatorHandler>();            
            

            #region ArquivoDigital -Contexto
            //Pasta
            services.AddTransient<IRequestHandler<AdicionarPastaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarPastaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarPastaComoPublicaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarPastaComoPrivadaCommand, ValidationResult>, PastaCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarPastaCommand, ValidationResult>, PastaCommandHandler>();

            //Arquivo
            services.AddTransient<IAzureStorage, AzureStorage>();
            services.AddTransient<IAzureStorageService, AzureStorageService>();
            services.AddTransient<IRequestHandler<AdicionarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddTransient<IRequestHandler<AlterarPastaDoArquivoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarArquivoComoPublicoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarArquivoComoPrivadoCommand, ValidationResult>, ArquivoCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarArquivoCommand, ValidationResult>, ArquivoCommandHandler>();

            #endregion


            #region Automacao -Contexto

            services.AddTransient<IDispositivosServiceFactory, DispositivoServiceFactory>();
            services.AddTransient<IRequestHandler<AdicionarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarCondominioCredencialCommand, ValidationResult>, CondominioCredencialCommandHandler>();

            #endregion


            #region Base Software -Contexto

            //Base software
            services.AddScoped<IBoletoService, BoletoService>();

            #endregion


            #region Comunicado -Contexto

            //Comunicado
            services.AddTransient<IRequestHandler<AdicionarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarComunicadoCommand, ValidationResult>, ComunicadoCommandHandler>();

            #endregion


            #region Correspondencia -Contexto

            //Correspondencia
            services.AddTransient<IRequestHandler<AdicionarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarCorrespondenciaVistaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarCorrespondenciaRetiradaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarCorrespondenciaDevolvidaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddTransient<IRequestHandler<DispararAlertaDeCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();
            services.AddTransient<IRequestHandler<GerarExcelCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();

            #endregion


            #region Enquete -Contexto

            //Enquete
            services.AddTransient<IRequestHandler<AdicionarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarDataFimDaEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarEnqueteCommand, ValidationResult>, EnqueteCommandHandler>();
            services.AddTransient<INotificationHandler<EnqueteCadastradaEvent>, EnqueteEventHandler>();

            //AlternativasEnquete
            services.AddTransient<IRequestHandler<AtualizarAlternativaCommand, ValidationResult>, AlternativaEnqueteCommandHandler>();
            services.AddTransient<IRequestHandler<RemoverAlternativaCommand, ValidationResult>, AlternativaEnqueteCommandHandler>();

            //RespostaEnquete
            services.AddTransient<IRequestHandler<CadastrarRespostaCommand, ValidationResult>, RespostaEnqueteCommandHandler>();

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
            services.AddTransient<INotificationHandler<EnviarEmailComunicadoIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddTransient<INotificationHandler<EnviarEmailCorrespondenciaIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddTransient<INotificationHandler<EnviarEmailEnqueteIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddTransient<INotificationHandler<EnviarEmailOcorrenciaIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddTransient<INotificationHandler<EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddTransient<INotificationHandler<EnviarEmailRespostaOcorrenciaParaAdministracaoIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddTransient<INotificationHandler<EnviarEmailReservaParaMoradorIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            services.AddTransient<INotificationHandler<EnviarEmailReservaParaAdministracaoIntegrationEvent>, NotificacaoEmailCondominioAppApiEventHandler>();
            #endregion


            #region NotificacaoPush -Contexto
            services.AddTransient<IRequestHandler<EnviarNotificacaoParaTodosNoCondominioCommand, ValidationResult>, NotificacaoPushCommandHandler>();
            services.AddTransient<INotificacaoPushService, NotificacaoPushService>();
            services.AddTransient<INotificationHandler<EnviarPushParaAdministracaoIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddTransient<INotificationHandler<EnviarPushParaMoradorIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddTransient<INotificationHandler<EnviarPushParaUnidadeIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddTransient<INotificationHandler<EnviarPushParaUnidadesIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddTransient<INotificationHandler<EnviarPushParaCondominioIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddTransient<INotificationHandler<EnviarPushParaProprietariosIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddTransient<INotificationHandler<EnviarPushParaProprietariosPorUnidadeIntegrationEvent>, NotificacaoPushEventHandler>();
            services.AddTransient<INotificationHandler<EnviarPushParaTodosIntegrationEvent>, NotificacaoPushEventHandler>();
            #endregion


            #region Ocorrencia -Contexto
            //Ocorrencia
            services.AddTransient<IRequestHandler<AdicionarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarOcorrenciaCommand, ValidationResult>, OcorrenciaCommandHandler>();

            //Resposta
            services.AddTransient<IRequestHandler<AdicionarRespostaOcorrenciaMoradorCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddTransient<IRequestHandler<AdicionarRespostaOcorrenciaSindicoCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarRespostaOcorrenciaComoVistaCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarRespostaOcorrenciaCommand, ValidationResult>, RespostaOcorrenciaCommandHandler>();
            #endregion


            #region Portaria -Contexto

            //Visitante                        
            services.AddTransient<IRequestHandler<AdicionarVisitantePorMoradorCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddTransient<IRequestHandler<AdicionarVisitantePorPorteiroCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarVisitantePorMoradorCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarVisitantePorPorteiroCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarVisitanteCommand, ValidationResult>, VisitanteCommandHandler>();
            services.AddTransient<INotificationHandler<VisitanteAdicionadoEvent>, VisitanteEventHandler>();
            services.AddTransient<INotificationHandler<VisitanteAtualizadoEvent>, VisitanteEventHandler>();
            services.AddTransient<INotificationHandler<VisitanteApagadoEvent>, VisitanteEventHandler>();

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
            services.AddTransient<IRequestHandler<AdicionarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarConfiguracaoCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddTransient<IRequestHandler<DefinirSindicoDoCondominioCommand, ValidationResult>, CondominioCommandHandler>();
            services.AddTransient<INotificationHandler<CondominioCadastradoEvent>, CondominioEventHandler>();
            services.AddTransient<INotificationHandler<CondominioEditadoEvent>, CondominioEventHandler>();
            services.AddTransient<INotificationHandler<CondominioConfiguracaoEditadoEvent>, CondominioEventHandler>();
            services.AddTransient<INotificationHandler<CondominioApagadoEvent>, CondominioEventHandler>();
            services.AddTransient<INotificationHandler<SindicoDoCondominioDefinidoEvent>, CondominioEventHandler>();


            //Grupo
            services.AddTransient<IRequestHandler<AdicionarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarGrupoCommand, ValidationResult>, GrupoCommandHandler>();
            services.AddTransient<INotificationHandler<GrupoCadastradoEvent>, GrupoEventHandler>();
            services.AddTransient<INotificationHandler<GrupoEditadoEvent>, GrupoEventHandler>();
            services.AddTransient<INotificationHandler<GrupoApagadoEvent>, GrupoEventHandler>();

            //Unidades
            services.AddTransient<IRequestHandler<AdicionarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddTransient<IRequestHandler<ResetCodigoUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarVagasDaUnidadeCommand, ValidationResult>, UnidadeCommandHandler>();
            services.AddTransient<INotificationHandler<UnidadeCadastradaEvent>, UnidadeEventHandler>();
            services.AddTransient<INotificationHandler<UnidadeEditadaEvent>, UnidadeEventHandler>();
            services.AddTransient<INotificationHandler<CodigoUnidadeResetadoEvent>, UnidadeEventHandler>();
            services.AddTransient<INotificationHandler<UnidadeRemovidaEvent>, UnidadeEventHandler>();
            services.AddTransient<INotificationHandler<VagaDeUnidadeEditadaEvent>, UnidadeEventHandler>();

            //Contratos
            services.AddTransient<IRequestHandler<AdicionarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarContratoCommand, ValidationResult>, ContratoCommandHandler>();
            

            #endregion


            #region ReservaAreaComum -Contexto

            //Area Comum
            services.AddTransient<IRequestHandler<AdicionarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddTransient<IRequestHandler<AtivarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();
            services.AddTransient<IRequestHandler<DesativarAreaComumCommand, ValidationResult>, AreaComumCommandHandler>();            
            services.AddTransient<INotificationHandler<AreaComumAdicionadaEvent>, AreaComumEventHandler>();
            services.AddTransient<INotificationHandler<AreaComumAtualizadaEvent>, AreaComumEventHandler>();
            services.AddTransient<INotificationHandler<AreaComumAtivadaEvent>, AreaComumEventHandler>();
            services.AddTransient<INotificationHandler<AreaComumDesativadaEvent>, AreaComumEventHandler>();
            services.AddTransient<INotificationHandler<AreaComumApagadaEvent>, AreaComumEventHandler>();

            //Reserva
            services.AddTransient<IRequestHandler<SolicitarReservaComoMoradorCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<SolicitarReservaComoAdministradorCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<AprovarReservaAutomaticamenteCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<AprovarReservaPelaAdministracaoCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<AguardarAprovacaoDaReservaPelaAdmCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<ReprovarReservaAutomaticamenteCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<ReprovarReservaPelaAdmCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<EnviarReservaParaFilaCommand, ValidationResult>, ReservaCommandHandler>();            
            services.AddTransient<IRequestHandler<CancelarReservaComoUsuarioCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<CancelarReservaComoAdministradorCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<RetirarReservaDaFilaCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarReservaComoExpiradaCommand, ValidationResult>, ReservaCommandHandler>();
            services.AddTransient<INotificationHandler<ReservaSolicitadaComoUsuarioEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaSolicitadaComoAdministradorEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaAprovadaAutomaticamenteEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaAprovadaPelaAdministracaoEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaEnviadaParaAguardarAprovacaoEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaReprovadaAutomaticamenteEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaReprovadaPelaAdmEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaEnviadaParaFilaEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaCanceladaPeloUsuarioEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaCanceladaPelaAdmEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaRetiradaDaFilaEvent>, ReservaEventHandler>();
            services.AddTransient<INotificationHandler<ReservaMarcadaComoExpiradaEvent>, ReservaEventHandler>();

            //Regras de Reserva
            services.AddTransient<IReservaStrategy, ReservaStrategy>();
            services.AddTransient<IRegrasDeCriacaoDeReserva, RegrasDeCriacaoDeReserva>();
            services.AddTransient<IRegrasDeAdministradorParaReservar, RegrasDeAdministradorParaReservar>();
            services.AddTransient<IRegrasDeMoradorParaReservar, RegrasDeMoradorParaReservar>();
            services.AddTransient<IRegrasGeraisParaReservar, RegrasGeraisParaReservar>();
            services.AddTransient<IRegraAntecedenciaMaxima, RegraAntecedenciaMaxima>();
            services.AddTransient<IRegraAntecedenciaMinima, RegraAntecedenciaMinima>();
            services.AddTransient<IRegraBloqueioDaAreaComum, RegraBloqueioDaAreaComum>();
            services.AddTransient<IRegraDataRetroativaNaoPermitida, RegraDataRetroativaNaoPermitida>();
            services.AddTransient<IRegraDataRetroativaPermitida, RegraDataRetroativaPermitida>();
            services.AddTransient<IRegraDiasPermitidos, RegraDiasPermitidos>();
            services.AddTransient<IRegraDuracaoLimite, RegraDuracaoLimite>();
            services.AddTransient<IRegraHorarioDentroDosLimites, RegraHorarioDentroDosLimites>();
            services.AddTransient<IRegraHorarioDisponivelComSobreposicao, RegraHorarioDisponivelComSobreposicao>();
            services.AddTransient<IRegraHorarioDisponivelSemSobreposicao, RegraHorarioDisponivelSemSobreposicao>();
            services.AddTransient<IRegraIntervaloParaMesmaUnidade, RegraIntervaloParaMesmaUnidade>();
            services.AddTransient<IRegraIntervalosFixos, RegraIntervalosFixos>();
            services.AddTransient<IRegraLimitePorUnidadePorDia, RegraLimitePorUnidadePorDia>();

            services.AddTransient<IRegrasDeCancelamentoDeReserva, RegrasDeCancelamentoDeReserva>();
            services.AddTransient<IRegrasDeCancelamentoDeReservaPeloMorador, RegrasDeCancelamentoDeReservaPeloMorador>();
            services.AddTransient<IRegrasDeCancelamentoDeReservaPelaAdministracao, RegrasDeCancelamentoDeReservaPelaAdministracao>();
            services.AddTransient<IRegraDoPrazoMinimoPraCancelar, RegraDoPrazoMinimoPraCancelar>();
            services.AddTransient<IRegraDoStatusPraCancelar, RegraDoStatusPraCancelar>();

            #endregion


            #region Usuarios -Context
            //Morador
            services.AddTransient<IRequestHandler<AdicionarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<IRequestHandler<RemoverMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarComoUnidadePrincipalCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<IRequestHandler<MarcarComoProprietarioCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<IRequestHandler<DesmarcarComoProprietarioCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<IRequestHandler<AtivarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<IRequestHandler<DesativarMoradorCommand, ValidationResult>, MoradorCommandHandler>();
            services.AddTransient<INotificationHandler<MoradorAdicionadoEvent>, MoradorEventHandler>();
            services.AddTransient<INotificationHandler<UnidadeMarcadaComoPrincipalEvent>, MoradorEventHandler>();
            services.AddTransient<INotificationHandler<MarcadoComoProprietarioEvent>, MoradorEventHandler>();
            services.AddTransient<INotificationHandler<DesmarcadoComoProprietarioEvent>, MoradorEventHandler>();
            services.AddTransient<INotificationHandler<MoradorRemovidoEvent>, MoradorEventHandler>();
            services.AddTransient<INotificationHandler<MoradorApagadoEvent>, MoradorEventHandler>();
            services.AddTransient<INotificationHandler<MoradorAtivadoEvent>, MoradorEventHandler>();
            services.AddTransient<INotificationHandler<MoradorDesativadoEvent>, MoradorEventHandler>();

            //Funcionario
            services.AddTransient<IRequestHandler<AdicionarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();            
            services.AddTransient<IRequestHandler<AtualizarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddTransient<IRequestHandler<AtivarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddTransient<IRequestHandler<DesativarFuncionarioCommand, ValidationResult>, FuncionarioCommandHandler>();
            services.AddTransient<INotificationHandler<FuncionarioAdicionadoEvent>, FuncionarioEventHandler>();
            services.AddTransient<INotificationHandler<FuncionarioAtualizadoEvent>, FuncionarioEventHandler>();
            services.AddTransient<INotificationHandler<FuncionarioAtivadoEvent>, FuncionarioEventHandler>();
            services.AddTransient<INotificationHandler<FuncionarioDesativadoEvent>, FuncionarioEventHandler>();

            //Usuario
            services.AddTransient<IRequestHandler<AdicionarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddTransient<IRequestHandler<RemoverUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarUltimoLoginUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddTransient<INotificationHandler<UsuarioEditadoEvent>, UsuarioEventHandler>();            

            //Veiculo
            services.AddTransient<IRequestHandler<AdicionarVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<ApagarVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();
            services.AddTransient<IRequestHandler<AtualizarVeiculoCommand, ValidationResult>, VeiculoCommandHandler>();            
            services.AddTransient<INotificationHandler<VeiculoCadastradoEvent>, VeiculoEventHandler>();
            services.AddTransient<INotificationHandler<UsuarioDoVeiculoNoCondominioEditadoEvent>, VeiculoEventHandler>();
            services.AddTransient<INotificationHandler<VeiculoRemovidoEvent>, VeiculoEventHandler>();
            services.AddTransient<INotificationHandler<VeiculoEditadoEvent>, VeiculoEventHandler>();
            
            //Mobile
            services.AddTransient<IRequestHandler<RegistrarMoradorMobileCommand, ValidationResult>, MobileCommandHandler>();
            services.AddTransient<IRequestHandler<RegistrarFuncionarioMobileCommand, ValidationResult>, MobileCommandHandler>();

            #endregion





            #region Querys     
            services.AddTransient<IArquivoDigitalQuery, ArquivoDigitalQuery>();
            services.AddScoped<IAutomacaoQuery, AutomacaoQuery>();
            services.AddScoped<IComunicadoQuery, ComunicadoQuery>();
            services.AddScoped<ICorrespondenciaQuery, CorrespondenciaQuery>();
            services.AddTransient<IEnqueteQuery, EnqueteQuery>();
            services.AddScoped<IOcorrenciaQuery, OcorrenciaQuery>();
            services.AddScoped<IPortariaQuery, PortariaQuery>();
            services.AddTransient<IPrincipalQuery, PrincipalQuery>();
            services.AddTransient<IReservaAreaComumQuery, ReservaAreaComumQuery>();
            services.AddScoped<IQueryLead, QueryLead>();
            services.AddTransient<IUsuarioQuery, UsuarioQuery>();
            #endregion


            #region Repositórios            
            services.AddTransient<IArquivoDigitalRepository, ArquivoDigitalRepository>();
            services.AddScoped<IAutomacaoRepository, AutomacaoRepository>();
            services.AddTransient<IComunidadoRepository, ComunicadoRepository>();
            services.AddScoped<ICorrespondenciaRepository, CorrespondenciaRepository>();
            services.AddTransient<IEnqueteRepository, EnqueteRepository>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddTransient<IOcorrenciaRepository, OcorrenciaRepository>();
            services.AddScoped<IPortariaRepository, PortariaRepository>();
            services.AddTransient<IPrincipalRepository, PrincipalRepository>();            
            services.AddTransient<IReservaAreaComumRepository, ReservaAreaComumRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            #endregion

            #region Repositórios Query               
            services.AddTransient<IFuncionarioQueryRepository, FuncionarioQueryRepository>();
            services.AddTransient<IMoradorQueryRepository, MoradorQueryRepository>();
            services.AddScoped<IPortariaQueryRepository, PortariaQueryRepository>();
            services.AddTransient<IPrincipalQueryRepository, PrincipalQueryRepository>();                        
            services.AddTransient<IReservaAreaComumQueryRepository, ReservaAreaComumQueryRepository>();            
            services.AddTransient<IVeiculoQueryRepository, VeiculoQueryRepository>();
            #endregion

            
        }
    }
}
