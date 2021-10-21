using NinjaStore.Core.Enumeradores;
using NinjaStore.Pedidos.Domain.FlatModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjaStore.Pedidos.Aplication.ViewModels
{    
    public class PedidoViewModel
   { 
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }


        public int Numero { get; set; }

        public StatusDePedido Status { get; set; }

        public string DescricaoDoStatus { get; set; }
       

        public string JustificativaDoCancelamento { get; set; }

        public decimal Valor { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorTotal { get; set; }


        public Guid ClienteId { get; set; }

        public string NomeDoCliente { get; set; }

        public string EmailDoCliente { get; set; }

        public string AldeiaDoCliente { get; set; }
        
        public List<ProdutoViewModel> Produtos { get; set; }



        public PedidoViewModel()
        {
        }

       
        public static PedidoViewModel Mapear(PedidoFlat flat)
        {
            return new PedidoViewModel
            {
                Id = flat.ClienteId,
                DataDeCadastro = flat.DataDeCadastro,
                DataDeCadastroFormatada = flat.DataDeCadastroFormatada,
                DataDeAlteracao = flat.DataDeAlteracao,
                DataDeAlteracaoFormatada = flat.DataDeAlteracaoFormatada,
                Numero = flat.Numero,
                Status = flat.Status,
                DescricaoDoStatus = flat.DescricaoDoStatus,
                JustificativaDoCancelamento = flat.JustificativaDoCancelamento,
                Valor = flat.Valor,
                Desconto = flat.Desconto,
                ValorTotal = flat.ValorTotal,
                ClienteId = flat.ClienteId,
                NomeDoCliente = flat.NomeDoCliente,
                EmailDoCliente = flat.EmailDoCliente,
                AldeiaDoCliente = flat.AldeiaDoCliente,
                Produtos = flat.Produtos.Select(ProdutoViewModel.Mapear).ToList()
            };
        }
    }
}
