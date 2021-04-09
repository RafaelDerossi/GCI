using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents
{
    public class EnviarPushParaTodosIntegrationEvent : IntegrationEvent
    {
        public string Titulo { get; set; }

        public string Conteudo { get; set; }


        public EnviarPushParaTodosIntegrationEvent(string titulo, string conteudo)
        {
            Conteudo = conteudo;
            Titulo = titulo;
        }
    }
}