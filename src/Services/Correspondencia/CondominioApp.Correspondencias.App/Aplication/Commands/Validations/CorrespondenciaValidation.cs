using System;
using FluentValidation;

namespace CondominioApp.Correspondencias.App.Aplication.Commands.Validations
{
    public abstract class CorrespondenciaValidation<T> : AbstractValidator<T> where T : CorrespondenciaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.CorrespondenciaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da correspondencia não pode estar vazio!"); ;
        }

        protected void ValidateCondominioId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Condominio não pode estar vazio!"); ;
        }

        protected void ValidateUnidadeId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty)
                .WithMessage("Unidade não pode estar vazio!"); ;
        }

        protected void ValidateNumeroUnidade()
        {
            RuleFor(c => c.NumeroUnidade)
                .NotNull().WithMessage("Número da Unidade não pode estar vazio!")
                .NotEmpty().WithMessage("Número da Unidade não pode estar vazio!");
        }

        protected void ValidateBloco()
        {
            RuleFor(c => c.Grupo)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("Bloco da Unidade não pode estar vazio!");
        }

        protected void ValidateVisto()
        {
            RuleFor(c => c.Visto)
                  .NotNull()
                  .WithMessage("Visto não pode estar vazio!");
        }

        protected void ValidateQuantidadeDeAlertasFeitos()
        {
            RuleFor(c => c.QuantidadeDeAlertasFeitos)
                  .NotNull()
                  .WithMessage("Quantidade de Alertas Feitos não pode estar vazio!");
        }

        protected void ValidateStatus()
        {
            RuleFor(c => c.Status)
                  .NotNull()
                  .WithMessage("Status não pode estar vazio!");
        }

        protected void ValidateCadastradoPorId()
        {
            RuleFor(c => c.CadastradaPorId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do Funcionário que cadastrou não pode estar vazio!"); ;
        }

        protected void ValidateCadastradoPorNome()
        {
            RuleFor(c => c.CadastradaPorNome)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("Nome do Funcionário que cadastrou não pode estar vazio!");
        }      

        protected void ValidateEntreguePorId()
        {
            RuleFor(c => c.EntreguePorId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do funcionário que entregou não pode estar vazio!"); ;
        }
        protected void ValidateEntreguePorNome()
        {
            RuleFor(c => c.EntreguePorNome)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("Nome do Funcionário que entregou não pode estar vazio!");
        }

        protected void ValidateNomeRetirante()
        {
            RuleFor(c => c.NomeRetirante)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("Nome do Retirante não pode estar vazio!");
        }

    }
}
