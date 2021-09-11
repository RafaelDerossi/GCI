using NinjaStore.Core.Messages;
using System;

namespace NinjaStore.Produtos.Aplication.Commands
{
    public abstract class ProdutoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }        

        public decimal Valor { get; protected set; }

        public string Foto { get; protected set; }

    }
}
