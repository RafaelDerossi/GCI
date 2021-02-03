using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class CadastrarCondominioCredencialCommand : CondominioCredencialCommand
    {
        public CadastrarCondominioCredencialCommand
            (string email, string senha, Guid condominioId)
        {
            SetEmail(email);
            SetSenha(senha);
            SetCondominioId(condominioId);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CadastrarCondominioCredencialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarCondominioCredencialCommandValidation : CondominioCredencialValidation<CadastrarCondominioCredencialCommand>
        {
            public CadastrarCondominioCredencialCommandValidation()
            {
                ValidateCondominioId();
                ValidateEmail();
                ValidateSenha();
            }
        }
    }
}
