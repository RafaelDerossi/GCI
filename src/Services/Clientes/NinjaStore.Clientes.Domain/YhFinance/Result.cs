using GCI.Core.DomainObjects;

namespace GCI.Acoes.Domain.YhFinance
{
    public class Result
    {
        public string ShortName { get; set; }

        public string LongName { get; set; }

        public string Currency { get; set; }        

        public decimal RegularMarketPreviousClose { get; set; }                        
        
        public decimal RegularMarketOpen { get; set; }

        public decimal RegularMarketChange { get; set; }

        public decimal RegularMarketChangePercent { get; set; }

        public decimal RegularMarketPrice { get; set; }        

        public decimal RegularMarketDayHigh { get; set; }

        public decimal RegularMarketDayLow { get; set; }


        public Result()
        {
        }      
    }
}
