using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Usuario
{
    public class EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent : IntegrationEvent
    {
        public Guid MoradorId { get; set; }        

        public EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent
            (Guid moradorId)
        {
            MoradorId = moradorId;            
        }
    }
}