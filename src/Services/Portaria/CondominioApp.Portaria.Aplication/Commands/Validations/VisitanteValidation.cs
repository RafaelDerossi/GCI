using CondominioApp.Core.Enumeradores;
using FluentValidation;
using System;

namespace CondominioApp.Portaria.Aplication.Commands.Validations
{
    public abstract class VisitanteValidation<T> : AbstractValidator<T> where T : VisitanteCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do Visitante não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do Visitante deve ter mais de 2 caracteres!");
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
                .NotNull().WithMessage("Número da Unidade não pode estar vazio!")
                .NotEmpty().WithMessage("Número da Unidade não pode estar vazio!");
        }
        protected void ValidateAndarUnidade()
        {
            RuleFor(c => c.AndarUnidade)
                .NotNull().WithMessage("Andar da Unidade não pode estar vazio!")                
                .NotEmpty().WithMessage("Andar da Unidade não pode estar vazio!");
        }
        protected void ValidateGrupoUnidade()
        {
            RuleFor(c => c.GrupoUnidade)
                .NotEmpty().WithMessage("Grupo da Unidade não pode estar vazio!")
                .Length(2, 200).WithMessage("Grupo da Unidade deve ter mais de 2 caracteres!");
        }
        protected void ValidateVisitantePermanente()
        {
            RuleFor(c => c.VisitantePermanente)
                  .NotNull()                
                  .WithMessage("Visitante Permanente deve ser informado!");
        }
        protected void ValidateTipoDeVisitante()
        {
            RuleFor(c => c.TipoDeVisitante)               
                .NotNull().WithMessage("Tipo de Visitante não pode estar vazio!");
        }
        

    }
}
