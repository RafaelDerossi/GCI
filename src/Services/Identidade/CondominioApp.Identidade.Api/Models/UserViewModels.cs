using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CondominioApp.Core.Enumeradores;

namespace CondominioApp.Identidade.Api.Models
{
    public class UsuarioLoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }

    public class UsuarioRespostaLoginViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
    }

    public class UsuarioTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaimViewModel> Claims { get; set; }
    }

    public class UsuarioClaimViewModel
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