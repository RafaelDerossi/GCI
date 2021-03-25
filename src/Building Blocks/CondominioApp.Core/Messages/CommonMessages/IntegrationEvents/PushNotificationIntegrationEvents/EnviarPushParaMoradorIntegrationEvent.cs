using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarPushParaMoradorIntegrationEvent : IntegrationEvent
    {
        public Guid UsuarioId { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }


        public EnviarPushParaMoradorIntegrationEvent(Guid usuarioId, string titulo, string conteudo)
        {
            UsuarioId = usuarioId;            
            Conteudo = conteudo;
            Titulo = titulo;
        }
    }
}