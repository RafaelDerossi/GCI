using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Enquete
{
    public class EnviarEmailEnqueteIntegrationEvent : IntegrationEvent
    {
        public string Descricao { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public Guid CondominioId { get; set; }

        public string NomeFuncionario { get; set; }

        public bool ApenasProprietarios { get; set; }

        public IEnumerable<string> Alternativas { get; set; }

        public EnviarEmailEnqueteIntegrationEvent
            (string descricao, string dataInicio, string dataFim, Guid condominioId,
             string nomeFuncionario, bool apenasProprietarios, IEnumerable<string> alternativas)
        {
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            CondominioId = condominioId;
            NomeFuncionario = nomeFuncionario;
            ApenasProprietarios = apenasProprietarios;
            Alternativas = alternativas;
        }
    }
}