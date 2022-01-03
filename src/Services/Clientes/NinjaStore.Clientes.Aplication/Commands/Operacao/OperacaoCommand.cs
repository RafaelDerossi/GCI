using System;
using GCI.Core.Messages.CommonMessages;
using GCI.Core.Enumeradores;

namespace GCI.Acoes.Aplication.Commands
{
    public abstract class OperacaoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string CodigoDaAcao { get; protected set; }

        public decimal Preco { get; protected set; }

        public int Quantidade { get; protected set; }

        public DateTime DataDaOperacao { get; protected set; }               

        public TipoOperacao Tipo { get; protected set; }

    }
}
