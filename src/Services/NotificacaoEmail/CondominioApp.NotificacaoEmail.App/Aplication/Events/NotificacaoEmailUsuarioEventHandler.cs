using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.NotificacaoEmail.Api.Email;
using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using MediatR;
using System.Linq;


namespace CondominioApp.NotificacaoEmail.Aplication.Events
{
    public class NotificacaoEmailUsuarioEventHandler : EventHandler, 
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent>,
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent>,        
        System.IDisposable
    {
        private IUsuarioQuery _usuarioQuery;
        private IPrincipalQuery _principalQuery;        

        public NotificacaoEmailUsuarioEventHandler
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
