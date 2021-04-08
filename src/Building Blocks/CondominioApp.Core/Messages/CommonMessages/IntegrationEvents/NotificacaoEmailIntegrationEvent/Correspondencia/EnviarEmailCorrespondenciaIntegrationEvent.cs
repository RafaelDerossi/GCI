using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EnviarEmailCorrespondenciaIntegrationEvent : IntegrationEvent
    {
        public string Assunto { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }
        
        public Guid UnidadeId { get; private set; }

        public EnviarEmailCorrespondenciaIntegrationEvent
            (string assunto, string titulo, string descricao, Guid unidadeId)
        {
            Assunto = assunto;
            Titulo = titulo;
            Descricao = descricao;
            UnidadeId = unidadeId;
        }
    }
}