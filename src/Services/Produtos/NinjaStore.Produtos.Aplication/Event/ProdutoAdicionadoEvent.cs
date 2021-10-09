using System;
namespace NinjaStore.Produtos.Aplication.Events
{
    public class ProdutoAdicionadoEvent : ProdutoEvent
    {

        public ProdutoAdicionadoEvent(Guid id, string descricao, decimal valor, string foto)
        {
            AggregateId = id;
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Foto = foto;
        }        
    }
}
