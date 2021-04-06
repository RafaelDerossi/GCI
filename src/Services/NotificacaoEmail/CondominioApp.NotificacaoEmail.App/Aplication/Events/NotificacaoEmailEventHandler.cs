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
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent>,
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

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastroDeUsuario(usuario));
            await DisparadorDeEmail.Disparar();
        }

        public async Task Handle(EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var morador = await _usuarioQueryRepository.ObterMoradorPorId(notification.MoradorId);

            var logoCondominio = "https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastroDeMorador(morador, logoCondominio));
            await DisparadorDeEmail.Disparar();
        }

        public void Dispose()
        {
            _usuarioQueryRepository?.Dispose();
        }        
    }
}
