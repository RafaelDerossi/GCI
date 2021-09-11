using NinjaStore.Pedidos.Aplication.DTO;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.Events
{
    public class PedidoAdicionadoEvent : PedidoEvent
    {

        public PedidoAdicionadoEvent
            (Guid id, int numero, decimal valor, decimal desconto, decimal valorTotal,
             ClienteDTO cliente, List<ProdutoDTO> produtos)
        {
            Id = id;
            Numero = numero;
            Valor = valor;
            Desconto = desconto;
            ValorTotal = valorTotal;
            Cliente = cliente;
            Produtos = produtos;
        }        
    }
}
