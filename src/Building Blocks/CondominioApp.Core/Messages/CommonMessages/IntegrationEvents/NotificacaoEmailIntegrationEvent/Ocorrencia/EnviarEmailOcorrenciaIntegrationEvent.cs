using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Ocorrencia
{
    public class EnviarEmailOcorrenciaIntegrationEvent : IntegrationEvent
    {
        public string Assunto { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string NomeMorador { get; set; }

        public string UnidadeDescricao { get; set; }

        public string StatusPrivacidade { get; set; }

        public string StatusOcorrencia { get; set; }

        public string DataDeCadastro { get; set; }

        public string Foto { get; set; }       
        
        public Guid UnidadeId { get; set; }

        public EnviarEmailOcorrenciaIntegrationEvent
            (string assunto, string titulo, string descricao, string nomeMorador,
             string unidadeDescricao, string statusPrivacidade, string statusOcorrencia,
             string dataDeCadastro, string foto, Guid unidadeId)
        {
            Assunto = assunto;
            Titulo = titulo;
            Descricao = descricao;
            NomeMorador = nomeMorador;
            UnidadeDescricao = unidadeDescricao;
            StatusPrivacidade = statusPrivacidade;
            StatusOcorrencia = statusOcorrencia;
            DataDeCadastro = dataDeCadastro;
            Foto = foto;
            UnidadeId = unidadeId;
        }
    }
}