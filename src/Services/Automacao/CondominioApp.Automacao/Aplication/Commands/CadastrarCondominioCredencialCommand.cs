using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class CadastrarCondominioCredencialCommand : CondominioCredencialCommand
    {
        public CadastrarCondominioCredencialCommand
            (string email, string senha, Guid condominioId, TipoApiAutomacao tipoApiAutomacao)
        {
            SetEmail(email);
            SetSenha(senha);
            SetCondominioId(condominioId);
            SetTipoApiAutomcao(tipoApiAutomacao);
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
                ValidateTipoApiAutomacao();
            }
        }
    }
}
