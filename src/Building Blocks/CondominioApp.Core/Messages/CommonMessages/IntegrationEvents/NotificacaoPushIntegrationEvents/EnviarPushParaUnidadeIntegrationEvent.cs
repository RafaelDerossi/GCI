using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents
{
    public class EnviarPushParaUnidadeIntegrationEvent : IntegrationEvent
    {
        public Guid UnidadeId { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }


        public EnviarPushParaUnidadeIntegrationEvent
            (Guid unidadeId, string titulo, string conteudo)
        {
            UnidadeId = unidadeId;            
            Conteudo = conteudo;
            Titulo = titulo;
        }
    }
}