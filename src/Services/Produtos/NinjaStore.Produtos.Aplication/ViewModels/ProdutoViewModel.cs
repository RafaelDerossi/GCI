using System;

namespace NinjaStore.Produtos.Domain.FlatModel
{    
    public class ProdutoViewModel
   {
        public Guid Id { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public string DataDeCadastroFormatada { get; private set; }

        public DateTime DataDeAlteracao { get; private set; }

        public string DataDeAlteracaoFormatada { get; private set; }       


        public string Descricao { get; private set; }

        public decimal Valor { get; private set; }

        public decimal Estoque { get; private set; }

        public string Foto { get; private set; }

        public ProdutoViewModel()
        {
        }

      
        public static ProdutoViewModel Mapear(ProdutoFlat flat)
        {
            return new ProdutoViewModel
            {
                Id = flat.ProdutoId,
                DataDeCadastro = flat.DataDeCadastro,
                DataDeCadastroFormatada = flat.DataDeCadastroFormatada,
                DataDeAlteracao = flat.DataDeAlteracao,
                DataDeAlteracaoFormatada = flat.DataDeAlteracaoFormatada,
                Descricao = flat.Descricao,
                Valor = flat.Valor,
                Estoque = flat.Estoque,
                Foto = flat.Foto
            };
        }

    }
}
