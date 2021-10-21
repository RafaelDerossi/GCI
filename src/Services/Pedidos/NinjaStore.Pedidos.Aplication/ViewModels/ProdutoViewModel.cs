using NinjaStore.Pedidos.Domain.FlatModel;
using System;

namespace NinjaStore.Pedidos.Aplication.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid ProdutoId { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        public decimal Valor { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorTotal { get; set; }

        public ProdutoViewModel()
        {
        }       

        public static ProdutoViewModel Mapear(ProdutoDoPedidoFlat flat)
        {
            return new ProdutoViewModel
            {
                ProdutoId = flat.ProdutoId,
                Descricao = flat.Descricao,
                Foto = flat.Foto,
                Valor = flat.Valor,
                Quantidade = flat.Quantidade,
                Desconto = flat.Desconto,
                ValorTotal = flat.ValorTotal
            };
        }
    }
}
