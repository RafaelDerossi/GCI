using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Usuario
{
    public class EnviarEmailRecuperarSenhaDeUsuarioIntegrationEvent : IntegrationEvent
    {
        public Guid UsuarioId { get; set; }

        public string LinkDeRedirecionamento { get; set; }

        public string Token { get; set; }

        public EnviarEmailRecuperarSenhaDeUsuarioIntegrationEvent
            (Guid usuarioId, string linkDeRedirecionamento, string token)
        {
            UsuarioId = usuarioId;
            LinkDeRedirecionamento = linkDeRedirecionamento;
            Token = token;
        }
    }
}