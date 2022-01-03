using System;

namespace GCI.Acoes.Domain.FlatModel
{    
    public class OperacaoViewModel
   { 
        public Guid Id { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }


        public string CodigoDaAcao { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataDaOperacao { get; set; }

        public decimal CustoDaOperacao { get; set; }

        public decimal ValorTotal { get; set; }       

        public string DescricaoTipoOperacao { get; set; }

        public OperacaoViewModel()
        {
        }        


        public static OperacaoViewModel Mapear(OperacaoFlat flat)
        {
            return new OperacaoViewModel
            {
                Id = flat.OperacaoId,
                DataDeCadastro = flat.DataDeCadastro,
                DataDeCadastroFormatada = flat.DataDeCadastroFormatada,
                DataDeAlteracao = flat.DataDeAlteracao,
                DataDeAlteracaoFormatada = flat.DataDeAlteracaoFormatada,
                CodigoDaAcao = flat.CodigoDaAcao,                
                Preco = flat.Preco,
                Quantidade = flat.Quantidade,
                DataDaOperacao = flat.DataDaOperacao,
                CustoDaOperacao = flat.CustoDaOperacao,
                ValorTotal = flat.ValorTotal,
                DescricaoTipoOperacao = flat.DescricaoTipoOperacao
            };
        }
    }
}
