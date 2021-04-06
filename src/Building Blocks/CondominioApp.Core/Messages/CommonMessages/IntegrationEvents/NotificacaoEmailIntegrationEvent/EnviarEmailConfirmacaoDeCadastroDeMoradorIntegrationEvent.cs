using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent : IntegrationEvent
    {
        public Guid UsuarioId { get; set; }        

        public EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent
            (Guid usuarioId)
        {
            UsuarioId = usuarioId;            
        }
    }
}