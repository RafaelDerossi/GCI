using GCI.Acoes.Aplication.Commands.Validations;
using System;

namespace GCI.Acoes.Aplication.Commands
{
    public class AdicionarClienteCommand : ClienteCommand
    {

        public AdicionarClienteCommand(string nome, string email, string aldeia)
        {            
            Nome = nome;
            Aldeia = aldeia;
            SetEmail(email);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarClienteCommandValidation : AcaoValidation<AdicionarClienteCommand>
        {
            public AdicionarClienteCommandValidation()
            {                               
                ValidateNome();
                ValidateEmail();
                ValidateAldeia();
            }
        }

    }
}
