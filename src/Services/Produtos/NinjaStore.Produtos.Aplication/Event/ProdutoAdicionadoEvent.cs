using System;
namespace NinjaStore.Produtos.Aplication.Events
{
    public class ProdutoAdicionadoEvent : ProdutoEvent
    {
        public ProdutoAdicionadoEvent
            (Guid produtoId, DateTime dataDeCadastro, string descricao,
             decimal valor, string foto, decimal estoque)
        {
            AggregateId = produtoId;
            ProdutoId = produtoId;
            DataDeCadastro = dataDeCadastro;
            Descricao = descricao;
            Valor = valor;
            Foto = foto;
            Estoque = estoque;
        }        
    }
}
