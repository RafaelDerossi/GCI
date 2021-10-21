using System;

namespace NinjaStore.Produtos.Domain.FlatModel
{    
    public class ProdutoViewModel
   {
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }       


        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public decimal Estoque { get; set; }

        public string Foto { get; set; }

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
