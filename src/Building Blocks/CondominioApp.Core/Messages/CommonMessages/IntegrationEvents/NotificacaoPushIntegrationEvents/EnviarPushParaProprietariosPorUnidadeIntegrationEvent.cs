using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarPushParaProprietariosPorUnidadeIntegrationEvent : IntegrationEvent
    {
        public IEnumerable<Guid> UnidadeIds { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }


        public EnviarPushParaProprietariosPorUnidadeIntegrationEvent(IEnumerable<Guid> unidadeIds, string titulo, string conteudo)
        {
            UnidadeIds = unidadeIds;            
            Conteudo = conteudo;
            Titulo = titulo;
        }
    }
}