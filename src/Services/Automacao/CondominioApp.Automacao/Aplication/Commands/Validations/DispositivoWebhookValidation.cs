using System;
using FluentValidation;

namespace CondominioApp.Automacao.App.Aplication.Commands.Validations
{
    public abstract class DispositivoWebhookValidation<T> : AbstractValidator<T> where T : DispositivoWebhookCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id não pode estar vazio!"); ;
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Condominio não pode estar vazio!"); ;
        }
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do condominio não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do condominio deve ter mais de 2 caracteres!");
        }

        protected void ValidateUrlLigar()
        {
            RuleFor(c => c.UrlLigar.Endereco)
                .NotNull().WithMessage("Webhook para ligar não pode estar vazio!")
                .Length(5, 255).WithMessage("Webhook para ligar deve ter entre 5 e 255 caracteres!");
        }

        protected void ValidateUrlDesligar()
        {
            RuleFor(c => c.UrlDesligar.Endereco)
                .NotNull().WithMessage("Webhook para desligar não pode estar vazio!")
                .Length(5, 255).WithMessage("Webhook para desligar deve ter mais de 5 e 255 caracteres!");
        }
    }
}
