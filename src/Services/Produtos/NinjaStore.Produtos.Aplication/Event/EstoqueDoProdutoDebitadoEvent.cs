using System;
namespace NinjaStore.Produtos.Aplication.Events
{
    public class EstoqueDoProdutoDebitadoEvent : ProdutoEvent
    {
        public decimal Quantidade { get; protected set; }

        public EstoqueDoProdutoDebitadoEvent
            (Guid id, decimal quantidade)
        {
            AggregateId = id;
            ProdutoId = id;            
            Quantidade = quantidade;
        }        
    }
}
