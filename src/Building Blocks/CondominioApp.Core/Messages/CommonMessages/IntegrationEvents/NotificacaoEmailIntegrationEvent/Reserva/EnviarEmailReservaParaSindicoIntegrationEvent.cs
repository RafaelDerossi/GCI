using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Reserva
{
    public class EnviarEmailReservaParaSindicoIntegrationEvent : IntegrationEvent
    {
        public string Titulo { get; set; }

        public string AreaComumNome { get; set; }

        public string DataRealizacao { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFim { get; set; }

        public Guid MoradorId { get; set; }        

        public string UnidadeDescricao { get; set; }

        public string Valor { get; set; }

        public string Observacao { get; set; }

        public string Justificativa { get; set; }

        public string DataDeCadastro { get; set; }

        public Guid CondominioId { get; set; }

        public Guid UnidadeId { get; set; }

        public string CorFundoTitulo { get; set; }

        public EnviarEmailReservaParaSindicoIntegrationEvent
            (string titulo, string areaComumNome, string dataRealizacao, string horaInicio, 
             string horaFim, Guid moradorId, string unidadeDescricao, string valor,
             string observacao, string justificativa, string dataDeCadastro, Guid condominioId,
             Guid unidadeId, string corFundoTitulo)
        {
            Titulo = titulo;
            AreaComumNome = areaComumNome;
            DataRealizacao = dataRealizacao;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            MoradorId = moradorId;
            UnidadeDescricao = unidadeDescricao;
            Valor = valor;
            Observacao = observacao;
            Justificativa = justificativa;
            DataDeCadastro = dataDeCadastro;
            CondominioId = condominioId;            
            UnidadeId = unidadeId;
            CorFundoTitulo = corFundoTitulo;
        }
    }
}