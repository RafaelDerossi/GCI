using System;
using System.Collections.Generic;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class ParceiroViewModel
    {
        public Guid ParceiroId { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime DataDeAlteracao { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }

        public string NomeCompleto { get; set; }

        public string Descricao { get; set; }

        public string LogoMarca { get; set; }

        public string Login { get; set; }

        public string Cor { get; set; }

        public string NumeroDoCnpj { get; set; }

        public string ValorDaSenha { get; set; }

        public string Logradouro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }

        public string Municipio { get; set; }

        public string ContratoDescricao { get; set; }

        public DateTime ContratoDataDeInicio { get; set; }

        public DateTime ContratoDataDeRenovacao { get; set; }

        public bool PreCadastro { get; set; }

        public string NomeDoResponsavel { get; set; }

        public string EmailDoResponsavel { get; set; }

        public string TelefoneFixo { get; set; }

        public string TelefoneCelular { get; set; }

        public bool Whatsapp { get; set; }

        public List<CondominioViewModel> Condominios { get; set; }
    }
}
