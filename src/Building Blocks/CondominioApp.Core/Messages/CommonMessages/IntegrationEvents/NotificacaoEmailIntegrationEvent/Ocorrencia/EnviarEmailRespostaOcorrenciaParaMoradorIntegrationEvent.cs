using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Ocorrencia
{
    public class EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent : IntegrationEvent
    {
        public string Titulo { get; set; }

        public string DescricaoDaOcorrencia { get; set; }

        public string Resposta { get; set; }

        public string NomeSindico { get; set; }                

        public string DataDaResposta { get; set; }

        public string Foto { get; set; }       
        
        public Guid moradorId { get; set; }        

        public EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent
            (string titulo, string descricaoDaOcorrencia, string resposta,
             string nomeSindico, string dataDaResposta, string foto, Guid moradorId)
        {
            Titulo = titulo;
            DescricaoDaOcorrencia = descricaoDaOcorrencia;
            Resposta = resposta;
            NomeSindico = nomeSindico;
            DataDaResposta = dataDaResposta;
            Foto = foto;
            this.moradorId = moradorId;
        }
    }
}