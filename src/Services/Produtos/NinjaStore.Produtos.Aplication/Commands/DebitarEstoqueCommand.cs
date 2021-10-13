using NinjaStore.Produtos.Aplication.Commands.Validations;
using System;

namespace NinjaStore.Produtos.Aplication.Commands
{
    public class DebitarEstoqueCommand : ProdutoCommand
    {
        public decimal Quantidade { get; protected set; }

        public DebitarEstoqueCommand(Guid produtoId, decimal quantidade)
        {
            AggregateId = produtoId;
            Id = produtoId;
            Quantidade = quantidade;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new DebitarEstoqueDeProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class DebitarEstoqueDeProdutoCommandValidation : ProdutoValidation<DebitarEstoqueCommand>
        {
            public DebitarEstoqueDeProdutoCommandValidation()
            {                
                ValidateId();                
            }
        }

    }
}
