using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AtualizarContratoCommand : ContratoCommand
    {
        public AtualizarContratoCommand(
            Guid id, DateTime dataAssinaturaContrato, TipoDePlano tipoDePlano,
            string descricaoContrato, bool ativo, int quantidadeDeUnidadesContratadas)
        {
            Id = id;            
            DataAssinatura = dataAssinaturaContrato;
            TipoPlano = tipoDePlano;
            DescricaoContrato = descricaoContrato;
            Ativo = ativo;
            QuantidadeDeUnidadesContratado = quantidadeDeUnidadesContratadas;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarContratoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarContratoCommandValidation : ContratoValidation<AtualizarContratoCommand>
        {
            public AtualizarContratoCommandValidation()
            {
                ValidateId();                       
            }
        }

    }
}
