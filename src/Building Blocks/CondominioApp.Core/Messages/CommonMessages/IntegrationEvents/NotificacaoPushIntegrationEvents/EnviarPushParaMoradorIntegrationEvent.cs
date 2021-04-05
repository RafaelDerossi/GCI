using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarPushParaMoradorIntegrationEvent : IntegrationEvent
    {
        public Guid MoradorId { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }


        public EnviarPushParaMoradorIntegrationEvent(Guid moradorId, string titulo, string conteudo)
        {
            MoradorId = moradorId;            
            Conteudo = conteudo;
            Titulo = titulo;
        }
    }
}