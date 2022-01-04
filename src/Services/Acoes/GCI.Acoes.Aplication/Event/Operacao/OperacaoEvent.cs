using GCI.Core.Enumeradores;
using GCI.Core.Messages.CommonMessages;
using System;

namespace GCI.Acoes.Aplication.Events
{
    public abstract class OperacaoEvent : Event
    {
        public System.Guid OperacaoId { get; protected set; }

        public System.DateTime DataDeCadastro { get; protected set; }

        public System.DateTime DataDeAlteracao { get; protected set; }

        public string CodigoDaAcao { get; protected set; }

        public decimal Preco { get; protected set; }

        public int Quantidade { get; protected set; }

        public System.DateTime DataDaOperacao { get; protected set; }

        public decimal CustoDaOperacao { get; protected set; }

        public decimal ValorTotal { get; protected set; }

        public TipoOperacao Tipo { get; protected set; }


    }
}
