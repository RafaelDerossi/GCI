using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class EditarContratoCommand : ContratoCommand
    {
        public EditarContratoCommand(
            Guid id, DateTime dataAssinaturaContrato, TipoDePlano tipoDePlano,
            string descricaoContrato, bool ativo, string linkContrato)
        {
            Id = id;            
            DataAssinatura = dataAssinaturaContrato;
            TipoPlano = tipoDePlano;
            DescricaoContrato = descricaoContrato;
            Ativo = ativo;
            LinkContrato = linkContrato;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarContratoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarContratoCommandValidation : ContratoValidation<EditarContratoCommand>
        {
            public EditarContratoCommandValidation()
            {
                ValidateId();                       
            }
        }

    }
}
