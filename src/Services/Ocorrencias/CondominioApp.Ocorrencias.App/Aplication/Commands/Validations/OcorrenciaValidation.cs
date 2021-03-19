using System;
using FluentValidation;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands.Validations
{
    public abstract class OcorrenciaValidation<T> : AbstractValidator<T> where T : OcorrenciaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);            
        }

        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)     
                  .NotNull()
                  .NotEmpty().WithMessage("Descricao da ocorrência não pode estar vazio!")
                  .Length(2, 200).WithMessage("Descricao da ocorrência deve ter entre 2 e 200 caracteres!");
        }

        protected void ValidatePublica()
        {
            RuleFor(c => c.Publica)
                  .NotNull();                  
        }

        protected void ValidateEmAndamento()
        {
            RuleFor(c => c.EmAndamento)
                  .NotNull();
        }

        protected void ValidateResolvida()
        {
            RuleFor(c => c.Resolvida)
                  .NotNull();
        }

        protected void ValidateParecer()
        {
            RuleFor(c => c.Parecer)                  
                  .NotEmpty().WithMessage("Parecer não pode estar vazio!")
                  .Length(2, 200).WithMessage("Parecer deve ter entre 2 e 200 caracteres!");
        }

        protected void ValidateUnidadeId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
        }       
        
        protected void ValidatePanico()
        {
            RuleFor(c => c.Panico)
                  .NotNull();                  
        }
       
    }
}
