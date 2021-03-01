using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Identidade.Api.Models
{
    public class UsuarioRegistro
    {
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo {0} precisa ter pelo menos {1} caracteres")]
        public string Nome { get; set; }

        public string Sobrenome { get; private set; }

        private string _Email;

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
        
        public string Telefone { get;  set; }

        public TipoDeUsuario TpUsuario { get; set; }

        public Permissao Permissao { get; set; }
        
        public string Atribuicao { get; set; }

        public string Funcao { get; set; }

        public bool SindicoProfissional { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string Foto { get; set; }

        public string NomeOriginal { get; set; }
        
        public DateTime DataDeNascimento { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public string Municipio { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Guid CondominioId { get; set; }

        public Guid UnidadeId { get; set; }

        public bool Proprietario { get; set; }

        public bool Principal { get; set; }
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }

    public class UsuarioRespostaLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }

    public class UsuarioToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }

    public class UsuarioClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class UsuarioSenhaViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }
    }

    public class UsuarioEsqueciSenhaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
    }

    public class UsuarioRedefinirSenhaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}