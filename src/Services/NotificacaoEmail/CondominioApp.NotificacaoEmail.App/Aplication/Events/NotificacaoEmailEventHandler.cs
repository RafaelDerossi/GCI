using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;


namespace CondominioApp.NotificacaoEmail.Aplication.Events
{
    public class NotificacaoEmailEventHandler : EventHandler, 
        INotificationHandler<EnviarPushParaSindicoIntegrationEvent>,       
        System.IDisposable
    {
        private IUsuarioQuery _usuarioQueryRepository;       

        public NotificacaoEmailEventHandler(IUsuarioQuery usuarioQueryRepository)
        {
            _usuarioQueryRepository = usuarioQueryRepository;            
        }

        public async Task Handle(EnviarPushParaSindicoIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var funcionario = await _usuarioQueryRepository.ObterSindicoPorCondominioId(notification.CondominioId);

            //var dispositivosIds = await ObterDispositivosIds(funcionario.Id);

            //var notificacaoDTO = new NotificacaoPushDTO(new SindicoOneSignalApp(), dispositivosIds);

            //notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, notification.Titulo, notification.Conteudo);

            //_notificacaoPushService.CriarNotificacao(notificacaoDTO);
            
        }
   

        public void Dispose()
        {
            _usuarioQueryRepository?.Dispose();
        }        
    }
}
