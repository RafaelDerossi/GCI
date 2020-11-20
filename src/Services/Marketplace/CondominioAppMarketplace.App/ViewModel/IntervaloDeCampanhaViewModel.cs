using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class IntervaloDeCampanhaViewModel
    {
        public Guid CampanhaId { get; set; }

        public DateTime NovaDataDeInicio { get; set; }

        public DateTime NovaDataDeFinal { get; set; }
    }
}
