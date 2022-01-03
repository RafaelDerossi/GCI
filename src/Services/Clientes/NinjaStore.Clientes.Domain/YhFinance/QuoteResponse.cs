using GCI.Core.DomainObjects;
using System.Collections.Generic;

namespace GCI.Acoes.Domain.YhFinance
{
    public class QuoteResponse
    {
        public List<Result> Result { get; set; }

        public QuoteResponse()
        {
            Result = new List<Result>();
        }      
    }
}
