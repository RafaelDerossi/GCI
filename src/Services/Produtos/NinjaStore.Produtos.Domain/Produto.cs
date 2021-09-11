using NinjaStore.Core.DomainObjects;
using System;

namespace NinjaStore.Produtos.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public const int Max = 200;        

        public string Descricao { get; private set; }

        public decimal Valor { get; private set; }

        public string Foto { get; private set; }

        protected Produto()
        {
        }

        public Produto(string descricao, decimal valor, string foto)
        {
            Descricao = descricao;
            Valor = valor;
            Foto = foto;
        }


        public void SetDescricao(string descricao) => Descricao = descricao;

        public void SetValor(decimal valor) => Valor = valor;

        public void SetFoto(string foto) => Foto = foto;

    }
}
