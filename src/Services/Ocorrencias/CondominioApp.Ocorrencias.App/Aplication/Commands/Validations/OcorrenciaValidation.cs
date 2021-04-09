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

        protected void ValidateMoradorId()
        {
            RuleFor(c => c.MoradorId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNomeMorador()
        {
            RuleFor(c => c.Descricao)
                  .NotNull()
                  .NotEmpty().WithMessage("Nome do Morador não pode estar vazio!")
                  .Length(2, 200).WithMessage("Nome do Morador deve ter entre 2 e 200 caracteres!");
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
