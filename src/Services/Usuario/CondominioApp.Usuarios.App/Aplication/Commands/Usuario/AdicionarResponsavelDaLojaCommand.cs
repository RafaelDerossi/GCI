using System;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Usuarios.App.Aplication.Commands.Validations;

namespace CondominioApp.Usuarios.App.Aplication.Commands
{
    public class AdicionarResponsavelDaLojaCommand : UsuarioCommand
    {
        public AdicionarResponsavelDaLojaCommand(Guid usuarioId, string nome, string sobrenome, string email, 
            string cpf = null, string cel = null)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Sobrenome = sobrenome;

            TipoDeUsuario = TipoDeUsuario.LOJISTA;
            Permissao = Permissao.USUARIO;

            SetCelular(cel);
            SetEmail(email);
            SetCpf(cpf);
        }

        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarResponsavelDaLojaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarResponsavelDaLojaCommandValidation : UsuarioValidation<AdicionarResponsavelDaLojaCommand>
        {
            public AdicionarResponsavelDaLojaCommandValidation()
            {
                ValidateNome();
                ValidateEmail();
                ValidateId();
            }
        }
    }
}