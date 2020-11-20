using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class CampanhaNovaViewModel
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Banner { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeFim { get; set; }

        public bool Ativo { get; set; }

        public bool TodosOsCondominios { get; set; }

        public Guid ItemDeVendaId { get; set; }
    }
}
