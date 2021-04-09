using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PushNotificationIntegrationEvent : IntegrationEvent
    {
        public List<Guid> UsuariosIds { get; private set; }

        public string Titulo { get; private set; }

        public string Conteudo { get; private set; }

        public TipoDePush TipoDePush { get; private set; }

        public PushNotificationIntegrationEvent(List<Guid> usuariosIds, string titulo,
            string conteudo, TipoDePush tipoDePush)
        {
            UsuariosIds = usuariosIds;
            Titulo = titulo;
            Conteudo = conteudo;
            TipoDePush = tipoDePush;
        }
    }
}
