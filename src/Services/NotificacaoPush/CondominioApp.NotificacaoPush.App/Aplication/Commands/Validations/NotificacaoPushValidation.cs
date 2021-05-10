using System;
using CondominioApp.NotificacaoPush.Commands;
using FluentValidation;

namespace CondominioApp.NotificacaoPush.App.Aplication.Commands.Validations
{
    public abstract class NotificacaoPushValidation<T> : AbstractValidator<T> where T : NotificacaoPushCommand
    {
        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Condominio não pode estar vazio!");
        }
       
        protected void ValidateTitulo()
        {
            RuleFor(c => c.Titulo)
                  .NotNull()
                  .NotEmpty();
        }

        protected void ValidateConteudo()
        {
            RuleFor(c => c.Conteudo)                 
                  .NotNull()
                  .NotEmpty().WithMessage("Conteúdo da notificação não pode estar vazio!")
                  .Length(2, 2000).WithMessage("Conteúdo da notificação deve ter mais de 1 caracter!");
        }
    }
}
