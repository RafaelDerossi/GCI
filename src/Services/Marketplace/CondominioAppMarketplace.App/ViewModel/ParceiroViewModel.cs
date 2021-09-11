using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CondominioAppMarketplace.App.ViewModel
{
    public class ParceiroViewModel
    {
        public Guid ParceiroId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        public string LogoMarca { get; set; }

        public string Cor { get; set; }

        public string NumeroDoCnpj { get; set; }

        public string Logradouro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }

        public string ContratoDescricao { get; set; }

        public DateTime ContratoDataDeInicio { get; set; }

        public DateTime ContratoDataDeRenovacao { get; set; }

        public bool PreCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeDoResponsavel { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string EmailDoResponsavel { get; set; }

        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TelefoneCelular { get; set; }

        public bool Whatsapp { get; set; }

        public string DataDeCadastroFormatada { get; set; }

        public string DataDeAlteracaoFormatada { get; set; }

        public CategoriaParceiro Categoria { get; set; }
    }
}
