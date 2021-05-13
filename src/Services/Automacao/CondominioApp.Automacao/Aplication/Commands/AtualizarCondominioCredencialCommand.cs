using CondominioApp.Automacao.App.Aplication.Commands.Validations;
using CondominioApp.Core.Enumeradores;
using System;

namespace CondominioApp.Automacao.App.Aplication.Commands
{
    public class AtualizarCondominioCredencialCommand : CondominioCredencialCommand
    {
        public AtualizarCondominioCredencialCommand
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

            ValidationResult = new AtualizarCondominioCredencialCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarCondominioCredencialCommandValidation : CondominioCredencialValidation<AtualizarCondominioCredencialCommand>
        {
            public AtualizarCondominioCredencialCommandValidation()
            {
                ValidateId();
                ValidateEmail();
                ValidateSenha();
                ValidateTipoApiAutomacao();
            }
        }
    }
}
