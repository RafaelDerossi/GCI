using FluentValidation;
using System;

namespace GCI.Acoes.Aplication.Commands.Validations
{
    public abstract class OperacaoValidation<T> : AbstractValidator<T> where T : OperacaoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }       
        protected void ValidateCodigo()
        {
            RuleFor(c => c.CodigoDaAcao)
                .NotEmpty().WithMessage("Código da Ação não pode estar vazia!")
                .Length(2, 50).WithMessage("Código da Ação deve ter entre 2 e 50 caracteres!");
        }       
        protected void ValidateQuantidade()
        {
            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("Quantidade deve ser maior que 0!");
        }
        protected void ValidatePreco()
        {
            RuleFor(c => c.Preco)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que 0!");
        }
        protected void ValidateDataDaOperacao()
        {
            RuleFor(c => c.DataDaOperacao)
                .NotNull()
                .WithMessage("Informe uma data para a operação!")
                .NotEmpty()
                .WithMessage("Informe uma data para a operação!");
        }
    }
}
