using System;

namespace CondominioAppMarketplace.App.Model
{
    public class ContratoModel
    {
        public Guid ParceiroId { get; set; }

        public string ContratoDescricao { get; set; }

        public DateTime ContratoDataDeInicio { get; set; }

        public DateTime ContratoDataDeRenovacao { get; set; }
    }
}
