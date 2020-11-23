using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class LeadNovoViewModel
    {
        public string NomeDoCondominio { get; set; }

        public string NomeDoCliente { get; set; }

        public string Bloco { get; set; }

        public string Unidade { get; set; }

        public string Observacao { get; set; }

        public string TelefoneDoCliente { get; set; }

        public string EmailDoMorador { get; set; }

        public Guid ItemDeVendaId { get; set; }
    }
}
