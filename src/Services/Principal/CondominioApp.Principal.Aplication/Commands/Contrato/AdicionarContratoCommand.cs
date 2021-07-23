using CondominioApp.Core.Enumeradores;
using CondominioApp.Principal.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Principal.Aplication.Commands
{
   public class AdicionarContratoCommand : ContratoCommand
    {
        public AdicionarContratoCommand(
            Guid condominioId, DateTime dataAssinaturaContrato, TipoDePlano tipoDePlano,
            string descricaoContrato, bool ativo, int quantidadeDeUnidadesContratadas, 
            string nomeOriginalArquivoContrato)
        {
            CondominioId = condominioId;
            DataAssinatura = dataAssinaturaContrato;
            TipoPlano = tipoDePlano;
            DescricaoContrato = descricaoContrato;
            Ativo = ativo;
            QuantidadeDeUnidadesContratado = quantidadeDeUnidadesContratadas;
            SetArquivoContrato(nomeOriginalArquivoContrato);
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
