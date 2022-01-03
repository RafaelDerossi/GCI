using GCI.Acoes.Domain.YhFinance;

namespace GCI.Acoes.Domain.FlatModel
{    
    public class CotacaoViewModel
   {         
        public string NomeCurto { get; set; }
        public string NomeLongo { get; set; }
        public string Moeda { get; set; }
        public decimal ValorUltimoFechamento { get; set; }
        public decimal ValorAbertura { get; set; }
        public decimal ValorOscilacao { get; set; }
        public decimal PorcentagemOscilacao { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal MaiorValorDoDia { get; set; }
        public decimal MenorValorDoDia { get; set; }


        public CotacaoViewModel()
        {
        }        


        public static CotacaoViewModel Mapear(Result cotacao)
        {
            return new CotacaoViewModel
            {
                NomeCurto = cotacao.ShortName,
                NomeLongo = cotacao.LongName,
                Moeda = cotacao.Currency,
                ValorUltimoFechamento = cotacao.RegularMarketPreviousClose,
                ValorAbertura = cotacao.RegularMarketOpen,
                ValorOscilacao = cotacao.RegularMarketChange,
                PorcentagemOscilacao = cotacao.RegularMarketChangePercent,
                ValorAtual = cotacao.RegularMarketPrice,
                MaiorValorDoDia = cotacao.RegularMarketDayHigh,
                MenorValorDoDia = cotacao.RegularMarketDayLow
            };
        }
    }
}
