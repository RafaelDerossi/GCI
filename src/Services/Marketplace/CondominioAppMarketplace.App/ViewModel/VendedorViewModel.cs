using System;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class VendedorViewModel
    {
        public Guid VendedorId { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }

        public string Nome { get;  set; }

        public string EmailDoVendedor { get; set; }

        public string CpfDoVendedor { get; set; }

        public string TelefoneDoVendedor { get; set; }

        public string logradouro { get;  set; }

        public string complemento { get; set; }

        public string numero { get; set; }

        public string cep { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string municipio { get; set; }

        public Guid ParceiroId { get; set; }

        public bool Whatsapp { get; set; }
    }
}