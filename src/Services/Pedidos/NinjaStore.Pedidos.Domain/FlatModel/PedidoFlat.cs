using NinjaStore.Core.DomainObjects;
using NinjaStore.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Domain.FlatModel
{
    [BsonCollection("PedidoFlat")]
    public class PedidoFlat : Document, IAggregateRoot
   {
        public Guid PedidoId { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public string DataDeCadastroFormatada
        {
            get
            {
                if (DataDeCadastro != null)
                    return DataDeCadastro.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }

        public DateTime DataDeAlteracao { get; private set; }

        public string DataDeAlteracaoFormatada
        {
            get
            {
                if (DataDeAlteracao != null)
                    return DataDeAlteracao.ToString("dd/MM/yyyy HH:mm");
                else
                    return null;
            }
        }               



        public int Numero { get; private set; }

        public StatusDePedido Status { get; private set; }

        public string DescricaoDoStatus
        {
            get
            {
                return Status switch
                {
                    StatusDePedido.PENDENTE => "Pendente",
                    StatusDePedido.APROVADO => "Aprovado",
                    StatusDePedido.CANCELADO => "Cancelado",
                    _ => "Pendente",
                };
            }
        }

        public string JustificativaDoCancelamento { get; private set; }

        public decimal Valor { get; private set; }

        public decimal Desconto { get; private set; }

        public decimal ValorTotal { get; private set; }


        public Guid ClienteId { get; private set; }

        public string NomeDoCliente { get; private set; }

        public string EmailDoCliente { get; private set; }

        public string AldeiaDoCliente { get; private set; }
       
        public List<ProdutoDoPedidoFlat> Produtos;


        protected PedidoFlat()
        {
            Produtos = new List<ProdutoDoPedidoFlat>();
        }

        public PedidoFlat
            (Guid pedidoId, DateTime dataDeCadastro, int numero, StatusDePedido status,
             decimal valor, decimal desconto, decimal valorTotal, Guid clienteId,
             string nomeDoCliente, string emailDoCliente, string aldeiaDoCliente)
        {
            Produtos = new List<ProdutoDoPedidoFlat>();
            PedidoId = pedidoId;
            DataDeCadastro = dataDeCadastro;
            Numero = numero;
            Status = status;
            Valor = valor;
            Desconto = desconto;
            ValorTotal = valorTotal;
            ClienteId = clienteId;
            NomeDoCliente = nomeDoCliente;
            EmailDoCliente = emailDoCliente;
            AldeiaDoCliente = aldeiaDoCliente;            
        }

        public void SetEntidadeId(Guid NovoId) => PedidoId = NovoId;        

        public void SetNumero(int numero) => Numero = numero;

        public void AdicionarProduto(ProdutoDoPedidoFlat produto)
        {
            Produtos.Add(produto);
        }

        public void AprovarPedido() => Status = StatusDePedido.APROVADO;

        public void CancelarPedido(string justificativa)
        {
            Status = StatusDePedido.CANCELADO;
            JustificativaDoCancelamento = justificativa;
        }
    }
}
