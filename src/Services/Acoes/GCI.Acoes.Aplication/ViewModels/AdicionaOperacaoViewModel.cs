using System;

namespace GCI.Acoes.Domain.FlatModel
{    
    public class AdicionaOperacaoViewModel
   {
        public string CodigoDaAcao { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataDaOperacao { get; set; }
        
        public AdicionaOperacaoViewModel()
        {
        }             
    }
}
