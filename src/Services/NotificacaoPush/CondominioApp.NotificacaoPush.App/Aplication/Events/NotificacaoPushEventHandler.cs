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
        INotificationHandler<EnviarPushParaProprietariosIntegrationEvent>,
        INotificationHandler<EnviarPushParaProprietariosPorUnidadeIntegrationEvent>,
        INotificationHandler<EnviarPushParaUnidadesIntegrationEvent>,
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

            var notificacaoDTO = new NotificacaoPushDTO(new SindicoOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);
            
        }

        public async Task Handle(EnviarPushParaMoradorIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIds(notification.MoradorId);

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);
        }

        public async Task Handle(EnviarPushParaUnidadeIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIdsPorUnidade(notification.UnidadeId);

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);                       

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);

        }

        public async Task Handle(EnviarPushParaCondominioIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIdsPorCondominio(notification.CondominioId);          

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);

        }

        public async Task Handle(EnviarPushParaProprietariosIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIdsDosProprietarios(notification.CondominioId);

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);
        }

        public async Task Handle(EnviarPushParaProprietariosPorUnidadeIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIdsDeProprietariosPorUnidade(notification.UnidadeIds);

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);
        }

        public async Task Handle(EnviarPushParaUnidadesIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIdsPorUnidades(notification.UnidadeIds);

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);
        }

        public async Task Handle(EnviarPushParaTodosIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var dispositivosIds = await ObterDispositivosIdsDeTodos();

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);

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

        private async Task<List<string>> ObterDispositivosIdsPorCondominio(System.Guid condominioId)
        {
            var moradores = await _usuarioQueryRepository.ObterMoradoresPorCondominioId(condominioId);

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

        private async Task<List<string>> ObterDispositivosIdsDosProprietarios(System.Guid condominioId)
        {
            var proprietarios = await _usuarioQueryRepository.ObterProprietariosPorCondominioId(condominioId);

            var dispositivosIds = new List<string>();

            foreach (MoradorFlat morador in proprietarios)
            {
                var dispositivos = await _usuarioQueryRepository.ObterMobilesPorMoradorFuncionarioId(morador.UsuarioId);
                foreach (Mobile dispositivo in dispositivos)
                {
                    dispositivosIds.Add(dispositivo.DeviceKey.ToString());
                }
            }

            return dispositivosIds;
        }

        private async Task<List<string>> ObterDispositivosIdsDeProprietariosPorUnidade(IEnumerable<System.Guid> unidadeIds)
        {
            var dispositivosIds = new List<string>();

            foreach (var item in unidadeIds)
            {
                var moradores = await _usuarioQueryRepository.ObterProprietariosPorUnidadeId(item);               

                foreach (MoradorFlat morador in moradores)
                {
                    var dispositivos = await _usuarioQueryRepository.ObterMobilesPorMoradorFuncionarioId(morador.UsuarioId);
                    foreach (Mobile dispositivo in dispositivos)
                    {
                        dispositivosIds.Add(dispositivo.DeviceKey.ToString());
                    }
                }
            }
            
            return dispositivosIds;
        }

        private async Task<List<string>> ObterDispositivosIdsPorUnidades(IEnumerable<System.Guid> unidadeIds)
        {
            var dispositivosIds = new List<string>();

            foreach (var item in unidadeIds)
            {
                var moradores = await _usuarioQueryRepository.ObterMoradoresPorUnidadeId(item);

                foreach (MoradorFlat morador in moradores)
                {
                    var dispositivos = await _usuarioQueryRepository.ObterMobilesPorMoradorFuncionarioId(morador.UsuarioId);
                    foreach (Mobile dispositivo in dispositivos)
                    {
                        dispositivosIds.Add(dispositivo.DeviceKey.ToString());
                    }
                }
            }

            return dispositivosIds;
        }

        private async Task<List<string>> ObterDispositivosIdsDeTodos()
        {
            var dispositivosIds = new List<string>();
            var dispositivos = await _usuarioQueryRepository.ObterTodosOsMobiles();
            foreach (Mobile dispositivo in dispositivos)
            {
                dispositivosIds.Add(dispositivo.DeviceKey.ToString());
            }
            return dispositivosIds;
        }


        public void Dispose()
        {
            _usuarioQueryRepository?.Dispose();
        }        
    }
}
