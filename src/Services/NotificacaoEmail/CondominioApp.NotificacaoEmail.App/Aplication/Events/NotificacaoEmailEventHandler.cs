using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.NotificacaoEmail.Api.Email;
using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using CondominioApp.Usuarios.App.Models;
using MediatR;


namespace CondominioApp.NotificacaoEmail.Aplication.Events
{
    public class NotificacaoEmailEventHandler : EventHandler, 
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent>,       
        System.IDisposable
    {
        private IUsuarioQuery _usuarioQueryRepository;       

        public NotificacaoEmailEventHandler(IUsuarioQuery usuarioQueryRepository)
        {
            _usuarioQueryRepository = usuarioQueryRepository;            
        }

        public async Task Handle(EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioQueryRepository.ObterPorId(notification.UsuarioId);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastroDeUsuario(usuario, notification.LinkDeRedirecionamento));
            await DisparadorDeEmail.Disparar();
        }
   

        public void Dispose()
        {
            _usuarioQueryRepository?.Dispose();
        }        
    }
}
