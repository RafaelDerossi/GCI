using FluentValidation;
using System;

namespace CondominioApp.Portaria.Aplication.Commands.Validations
{
    public abstract class VisitaValidation<T> : AbstractValidator<T> where T : VisitaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNomeCondomino()
        {
            RuleFor(c => c.NomeCondomino)
                .NotEmpty().WithMessage("Nome do Condômino não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do Condômino deve ter mais de 2 caracteres!");
        }       
        protected void ValidateObservacao()
        {
            RuleFor(c => c.NomeCondominio)                
                .Length(0, 250).WithMessage("Observação deve ter no máximo 250 caracteres!");
        }
        protected void ValidateStatus()
        {
            RuleFor(c => c.Status)
                .NotNull().WithMessage("Status não pode estar vazio!");
        }


        protected void ValidateVisitanteId()
        {
            RuleFor(c => c.VisitanteId)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNomeVisitante()
        {
            RuleFor(c => c.NomeVisitante)
                .NotEmpty().WithMessage("Nome do Visitante não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do Visitante deve ter mais de 2 caracteres!");
        }
        protected void ValidateTipoDeDocumentoVisitante()
        {
            RuleFor(c => c.TipoDeDocumentoVisitante)
                .NotNull().WithMessage("Tipo de Documento do Visitante não pode estar vazio!");
        }


        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNomeCondominio()
        {
            RuleFor(c => c.NomeCondominio)
                .NotEmpty().WithMessage("Nome do condominio não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do condominio deve ter mais de 2 caracteres!");
        }


        protected void ValidateUnidadeId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNumeroUnidade()
        {
            RuleFor(c => c.NumeroUnidade)
                .NotEmpty().WithMessage("Numero da Unidade não pode estar vazio!")
                .Length(2, 200).WithMessage("Numero da Unidade deve ter mais de 2 caracteres!");
        }
        protected void ValidateAndarUnidade()
        {
            RuleFor(c => c.AndarUnidade)
                .NotEmpty().WithMessage("Andar da Unidade não pode estar vazio!")
                .Length(2, 200).WithMessage("Andar da Unidade deve ter mais de 2 caracteres!");
        }
        protected void ValidateGrupoUnidade()
        {
            RuleFor(c => c.GrupoUnidade)
                .NotEmpty().WithMessage("Grupo da Unidade não pode estar vazio!")
                .Length(2, 200).WithMessage("Grupo da Unidade deve ter mais de 2 caracteres!");
        }
             

    }
}
