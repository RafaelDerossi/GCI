using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class DefinirSindicoDoCondominioCommand : CondominioCommand
    {

        public DefinirSindicoDoCondominioCommand(Guid condominioId, Guid funcionarioIdDoSindico, string nomeDoSindico)
        {
            Id = condominioId;
            FuncionarioIdDoSindico = funcionarioIdDoSindico;
            NomeDoSindico = nomeDoSindico;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DefinirSindicoDoCondominioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DefinirSindicoDoCondominioCommandValidation : CondominioValidation<DefinirSindicoDoCondominioCommand>
        {
            public DefinirSindicoDoCondominioCommandValidation()
            {
                ValidateId();
                ValidateFuncionarioIdDoSindico();
                ValidateNomeDoSindico();
            }
        }

    }
}
