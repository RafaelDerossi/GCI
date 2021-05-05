using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents
{
    public class EnviarPushParaAdministracaoIntegrationEvent : IntegrationEvent
    {
        public Guid CondominioId { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }


        public EnviarPushParaAdministracaoIntegrationEvent(Guid condominioId, string titulo, string conteudo)
        {            
            CondominioId = condominioId;            
            Conteudo = conteudo;
            Titulo = titulo;
        }
    }
}