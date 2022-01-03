using GCI.Core.DomainObjects;
using System.Collections.Generic;

namespace GCI.Acoes.Domain.YhFinance
{
    public class QuoteResponse
    {
        public IEnumerable<Result> Results { get; set; }

        public QuoteResponse()
        {
        }      
    }
}
