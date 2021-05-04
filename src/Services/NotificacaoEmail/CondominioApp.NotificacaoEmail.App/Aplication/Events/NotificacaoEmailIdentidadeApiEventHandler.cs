using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.NotificacaoEmail.Api.Email;
using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using MediatR;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Usuario;

namespace CondominioApp.NotificacaoEmail.Aplication.Events
{
    public class NotificacaoEmailIdentidadeApiEventHandler : EventHandler, 
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent>,
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent>,        
        System.IDisposable
    {
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IPrincipalQuery _principalQuery;        

        public NotificacaoEmailIdentidadeApiEventHandler
            (IUsuarioQuery usuarioQuery, IPrincipalQuery principalQuery)
        {
            _usuarioQuery = usuarioQuery;
            _principalQuery = principalQuery;
        }


        public async Task Handle(EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioQuery.ObterPorId(notification.UsuarioId);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastroDeUsuario(usuario));
            await DisparadorDeEmail.Disparar();
        }

        public async Task Handle(EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(notification.MoradorId);

            var condominio = await _principalQuery.ObterPorId(morador.CondominioId);

            var logoCondominio = condominio.LogoMarca; //"https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastroDeMorador(morador, logoCondominio));
            await DisparadorDeEmail.Disparar();
        }



        public void Dispose()
        {
            _usuarioQuery?.Dispose();
        }        
    }
}
