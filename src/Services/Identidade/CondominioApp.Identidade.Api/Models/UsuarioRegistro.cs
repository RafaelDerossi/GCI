using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Identidade.Api.Models
{
    public abstract class UsuarioRegistro
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo {0} precisa ter pelo menos {1} caracteres")]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        protected string _Email;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get { return _Email; } set { _Email = string.IsNullOrWhiteSpace(value) ? null : value; } }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(12, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Celular { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Telefone { get; set; }

        public TipoDeUsuario TpUsuario { get; set; }        

        public DateTime? DataNascimento { get; set; }

        public string Foto { get; set; }

        public string NomeOriginal { get; set; }


        //Endereço
        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

    }
}
