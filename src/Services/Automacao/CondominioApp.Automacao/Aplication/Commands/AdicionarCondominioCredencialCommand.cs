using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class AdicionarCondominioCredencialCommand : CondominioCredencialCommand
    {
        public AdicionarCondominioCredencialCommand
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

            ValidationResult = new AdicionarCondominioCredencialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarCondominioCredencialCommandValidation : CondominioCredencialValidation<AdicionarCondominioCredencialCommand>
        {
            public AdicionarCondominioCredencialCommandValidation()
            {
                ValidateCondominioId();
                ValidateEmail();
                ValidateSenha();
                ValidateTipoApiAutomacao();
            }
        }
    }
}
