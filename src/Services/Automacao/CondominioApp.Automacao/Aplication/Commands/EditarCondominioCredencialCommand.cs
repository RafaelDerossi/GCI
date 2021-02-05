using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class EditarCondominioCredencialCommand : CondominioCredencialCommand
    {
        public EditarCondominioCredencialCommand
            (Guid id, string email, string senha, TipoApiAutomacao tipoApiAutomacao)
        {
            Id = id;
            SetEmail(email);
            SetSenha(senha);            
            SetTipoApiAutomcao(tipoApiAutomacao);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarCondominioCredencialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarCondominioCredencialCommandValidation : CondominioCredencialValidation<EditarCondominioCredencialCommand>
        {
            public EditarCondominioCredencialCommandValidation()
            {
                ValidateId();
                ValidateEmail();
                ValidateSenha();
                ValidateTipoApiAutomacao();
            }
        }
    }
}
