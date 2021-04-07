using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent : IntegrationEvent
    {
        public Guid UsuarioId { get; set; }        

        public EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }
}