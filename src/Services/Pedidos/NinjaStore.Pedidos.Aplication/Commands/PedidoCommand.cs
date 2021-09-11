using NinjaStore.Core.Messages;
using NinjaStore.Pedidos.Aplication.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.Commands
{
    public abstract class PedidoCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Numero { get; protected set; }

        public ClienteDTO Cliente { get; protected set; }        

        public List<ProdutoDTO> Produtos { get; protected set; }

    }
}
