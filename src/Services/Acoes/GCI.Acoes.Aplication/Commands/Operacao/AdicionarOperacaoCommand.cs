using GCI.Acoes.Aplication.Commands.Validations;
using GCI.Core.Enumeradores;
using System;

namespace GCI.Acoes.Aplication.Commands
{
    public class AdicionarOperacaoCommand : OperacaoCommand
    {
        public AdicionarOperacaoCommand
            (string codigoDaAcao, decimal preco, int quantidade, DateTime dataDaOperacao, TipoOperacao tipo)
        {
            CodigoDaAcao = codigoDaAcao;
            Preco = preco;
            Quantidade = quantidade;
            DataDaOperacao = dataDaOperacao;
            Tipo = tipo;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarOperacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarOperacaoCommandValidation : OperacaoValidation<AdicionarOperacaoCommand>
        {
            public AdicionarOperacaoCommandValidation()
            {                               
                ValidateCodigo();
                ValidateQuantidade();
                ValidatePreco();
                ValidateDataDaOperacao();
            }
        }

    }
}
