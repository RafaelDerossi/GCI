using System;
using FluentValidation;

namespace CondominioApp.Ocorrencias.App.Aplication.Commands.Validations
{
    public abstract class RespostaOcorrenciaValidation<T> : AbstractValidator<T> where T : RespostaOcorrenciaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);            
        }
        protected void ValidateOcorrenciaId()
        {
            RuleFor(c => c.OcorrenciaId)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)     
                  .NotNull()
                  .NotEmpty().WithMessage("Descricao da resposta não pode estar vazio!")
                  .Length(2, 200).WithMessage("Descricao da resposta deve ter entre 2 e 200 caracteres!");
        }        

        protected void ValidateAutorId()
        {
            RuleFor(c => c.AutorId)
                .NotEqual(Guid.Empty);
        }       
       
    }
}
