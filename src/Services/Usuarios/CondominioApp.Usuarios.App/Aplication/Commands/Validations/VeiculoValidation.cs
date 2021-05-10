using FluentValidation;
using System;

namespace CondominioApp.Usuarios.App.Aplication.Commands.Validations
{
    public abstract class VeiculoValidation<T> : AbstractValidator<T> where T : VeiculoCommand
    {
        protected void ValidateVeiculoId()
        {
            RuleFor(c => c.VeiculoId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateVeiculoCondominioId()
        {
            RuleFor(c => c.VeiculoCondominioId)
                .NotEqual(Guid.Empty);
        }


        protected void ValidatePlaca()
        {
            RuleFor(c => c.Placa)
                .NotNull().WithMessage("Placa não pode estar vazio!")
                .NotEmpty().WithMessage("Placa não pode estar vazio!")
                .Length(7, 7).WithMessage("Placa deve ter 7 caracteres!");
        }
        protected void ValidateModelo()
        {
            RuleFor(c => c.Modelo)
                  .NotNull().WithMessage("Modelo não pode estar vazio!")
                  .NotEmpty().WithMessage("Modelo não pode estar vazio!")
                  .Length(3, 200).WithMessage("Modelo deve ter mais de 2 caracteres!");                  
        }
        protected void ValidateCor()
        {
            RuleFor(c => c.Cor)
                  .NotNull().WithMessage("Cor não pode estar vazio!")
                  .NotEmpty().WithMessage("Cor não pode estar vazio!")
                  .Length(3, 30).WithMessage("Cor deve ter mais de 2 caracteres!");
        }

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUnidadeId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNumeroUnidade()
        {
            RuleFor(c => c.NumeroUnidade)
                  .NotNull().WithMessage("Numero da Unidade do Condomínio não pode estar vazio!")
                  .NotEmpty().WithMessage("Numero da Unidade não pode estar vazio!");
        }
        protected void ValidateAndarUnidade()
        {
            RuleFor(c => c.AndarUnidade)
                  .NotNull().WithMessage("Andar da Unidade do Condomínio não pode estar vazio!")
                  .NotEmpty().WithMessage("Andar da Unidade não pode estar vazio!");
        }
        protected void ValidateGrupoDaUnidade()
        {
            RuleFor(c => c.GrupoUnidade)
                  .NotNull().WithMessage("Grupo da Unidade não pode estar vazio!")
                  .NotEmpty().WithMessage("Grupo da Unidade não pode estar vazio!");
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNomeCondominio()
        {
            RuleFor(c => c.NomeCondominio)
                  .NotNull().WithMessage("Nome do Condomínio não pode estar vazio!")
                  .NotEmpty().WithMessage("Nome do Condomínio não pode estar vazio!");
        }
    }
}
