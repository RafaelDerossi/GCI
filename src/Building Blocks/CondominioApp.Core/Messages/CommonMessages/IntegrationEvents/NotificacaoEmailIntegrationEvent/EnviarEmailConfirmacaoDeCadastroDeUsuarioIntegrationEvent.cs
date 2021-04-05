using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent : IntegrationEvent
    {
        public Guid UsuarioId { get; set; }      

        public string LinkDeRedirecionamento { get; set; }

        public EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent
            (Guid usuarioId, string linkDeRedirecionamento)
        {
            UsuarioId = usuarioId;
            LinkDeRedirecionamento = linkDeRedirecionamento;
        }
    }
}