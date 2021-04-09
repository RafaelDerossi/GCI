using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Ocorrencia
{
    public class EnviarEmailRespostaOcorrenciaParaSindicoIntegrationEvent : IntegrationEvent
    {
        public string Titulo { get; set; }

        public string DescricaoDaOcorrencia { get; set; }

        public string Resposta { get; set; }

        public string NomeMorador { get; set; }        

        public string StatusOcorrencia { get; set; }

        public string DataDaResposta { get; set; }

        public string Foto { get; set; }       
        
        public Guid CondominioId { get; set; }

        public EnviarEmailRespostaOcorrenciaParaSindicoIntegrationEvent
            (string titulo, string descricaoDaOcorrencia, string resposta, string nomeMorador,
             string statusOcorrencia, string dataDaResposta, string foto, Guid condominioId)
        {
            Titulo = titulo;
            DescricaoDaOcorrencia = descricaoDaOcorrencia;
            Resposta = resposta;
            NomeMorador = nomeMorador;
            StatusOcorrencia = statusOcorrencia;
            DataDaResposta = dataDaResposta;
            Foto = foto;
            CondominioId = condominioId;
        }
    }
}