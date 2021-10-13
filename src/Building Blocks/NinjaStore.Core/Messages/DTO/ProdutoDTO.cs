using System;

namespace NinjaStore.Core.Messages.DTO
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        public decimal Valor { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorTotal { get; set; }

        public ProdutoDTO()
        {
        }

        public ProdutoDTO
            (Guid id, Guid produtoId, string descricao, string foto, decimal valor,
             decimal quantidade, decimal desconto, decimal valorTotal)
        {
            Id = id;
            ProdutoId = produtoId;
            Descricao = descricao;
            Foto = foto;
            Valor = valor;
            Quantidade = quantidade;
            Desconto = desconto;
            ValorTotal = valorTotal;
        }
    }
}
