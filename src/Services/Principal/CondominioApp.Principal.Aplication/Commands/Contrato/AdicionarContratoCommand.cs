using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AdicionarContratoCommand : ContratoCommand
    {
        public AdicionarContratoCommand(
            Guid condominioId, DateTime dataAssinaturaContrato, TipoDePlano tipoDePlano,
            string descricaoContrato, bool ativo, string linkContrato)
        {
            CondominioId = condominioId;
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

            ValidationResult = new AdicionarContratoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarContratoCommandValidation : ContratoValidation<AdicionarContratoCommand>
        {
            public AdicionarContratoCommandValidation()
            {
                ValidateCondominioId();            
            }
        }

    }
}
