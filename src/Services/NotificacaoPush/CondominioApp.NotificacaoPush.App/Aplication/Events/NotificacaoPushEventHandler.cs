using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.NotificacaoPush.App.DTO;
using CondominioApp.NotificacaoPush.App.OneSignalApps;
using CondominioApp.NotificacaoPush.App.Services.Interfaces;
using CondominioApp.OneSignal.Recursos;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.Data;
using CondominioApp.Usuarios.App.Data.Repository;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;


namespace CondominioApp.Principal.Aplication.Events
{
    public class NotificacaoPushEventHandler : EventHandler, 
        INotificationHandler<EnviarPushParaSindicoIntegrationEvent>,
        INotificationHandler<EnviarPushParaMoradorIntegrationEvent>,
        INotificationHandler<EnviarPushParaUnidadeIntegrationEvent>,
        INotificationHandler<EnviarPushParaCondominioIntegrationEvent>,
        INotificationHandler<EnviarPushParaTodosIntegrationEvent>,
        System.IDisposable
    {
        private IUsuarioQuery _usuarioQueryRepository;
        private INotificacaoPushService _notificacaoPushService;

        public NotificacaoPushEventHandler(IUsuarioQuery usuarioQueryRepository, INotificacaoPushService notificacaoPushService)
        {
            _usuarioQueryRepository = usuarioQueryRepository;
            _notificacaoPushService = notificacaoPushService;
        }

        public async Task Handle(EnviarPushParaSindicoIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var funcionario = await _usuarioQueryRepository.ObterSindicoPorCondominioId(notification.CondominioId);

            var dispositivosIds = await ObterDispositivosIds(funcionario.Id);           

            var notificacaoDTO = new NotificacaoPushDTO();            
            
            notificacaoDTO.AppOneSignal = new SindicoOneSignalApp();                                       

            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notification.Titulo);

            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notification.Conteudo);

            notificacaoDTO.DispositivosIds = dispositivosIds;

            var retorno =  _notificacaoPushService.CriarNotificacao(notificacaoDTO);

            
        }

        public async Task Handle(EnviarPushParaMoradorIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIds(notification.MoradorId);
           
            var notificacaoDTO = new NotificacaoPushDTO();

            notificacaoDTO.AppOneSignal = new MoradorOneSignalApp();

            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notification.Titulo);

            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notification.Conteudo);

            notificacaoDTO.DispositivosIds = dispositivosIds;

            var retorno = _notificacaoPushService.CriarNotificacao(notificacaoDTO);
        }

        public async Task Handle(EnviarPushParaUnidadeIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIdsPorUnidade(notification.UnidadeId);
            
            var notificacaoDTO = new NotificacaoPushDTO();

            notificacaoDTO.AppOneSignal = new MoradorOneSignalApp();

            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notification.Titulo);

            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notification.Conteudo);

            notificacaoDTO.DispositivosIds = dispositivosIds;

            var retorno = _notificacaoPushService.CriarNotificacao(notificacaoDTO);


        }

        public async Task Handle(EnviarPushParaCondominioIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var moradores = await _usuarioQueryRepository.ObterMoradoresPorCondominioId(notification.CondominioId);

            var dispositivosIds = new List<string>();

            foreach (MoradorFlat morador in moradores)
            {
                var dispositivos = await _usuarioQueryRepository.ObterMobilesPorMoradorFuncionarioId(morador.UsuarioId);
                foreach (Mobile dispositivo in dispositivos)
                {
                    dispositivosIds.Add(dispositivo.DeviceKey.ToString());
                }
            }

            var notificacaoDTO = new NotificacaoPushDTO();

            notificacaoDTO.AppOneSignal = new MoradorOneSignalApp();

            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notification.Titulo);

            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notification.Conteudo);

            notificacaoDTO.DispositivosIds = dispositivosIds;

            var retorno = _notificacaoPushService.CriarNotificacao(notificacaoDTO);


        }

        public async Task Handle(EnviarPushParaTodosIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = new List<string>();

            var dispositivos = await _usuarioQueryRepository.ObterTodosOsMobiles();
            foreach (Mobile dispositivo in dispositivos)
            {
                dispositivosIds.Add(dispositivo.DeviceKey.ToString());
            }

            var notificacaoDTO = new NotificacaoPushDTO();

            notificacaoDTO.AppOneSignal = new MoradorOneSignalApp();

            notificacaoDTO.Titulos.Add(CodigosDeLingua.English, notification.Titulo);

            notificacaoDTO.Conteudo.Add(CodigosDeLingua.English, notification.Conteudo);

            notificacaoDTO.DispositivosIds = dispositivosIds;

            var retorno = _notificacaoPushService.CriarNotificacao(notificacaoDTO);


        }


        private async Task<List<string>> ObterDispositivosIds(System.Guid moradorIdFuncionarioId)
        {
            var dispositivosIds = new List<string>();
            var dispositivos = await _usuarioQueryRepository.ObterMobilesPorMoradorFuncionarioId(moradorIdFuncionarioId);
            foreach (Mobile dispositivo in dispositivos)
            {
                dispositivosIds.Add(dispositivo.DeviceKey.ToString());
            }
            return dispositivosIds;
        }

        private async Task<List<string>> ObterDispositivosIdsPorUnidade(System.Guid unidadeId)
        {
            var moradores = await _usuarioQueryRepository.ObterMoradoresPorUnidadeId(unidadeId);

            var dispositivosIds = new List<string>();

            foreach (MoradorFlat morador in moradores)
            {
                var dispositivos = await _usuarioQueryRepository.ObterMobilesPorMoradorFuncionarioId(morador.UsuarioId);
                foreach (Mobile dispositivo in dispositivos)
                {
                    dispositivosIds.Add(dispositivo.DeviceKey.ToString());
                }
            }
            return dispositivosIds;
        }

        public void Dispose()
        {
            _usuarioQueryRepository?.Dispose();
        }        
    }
}
