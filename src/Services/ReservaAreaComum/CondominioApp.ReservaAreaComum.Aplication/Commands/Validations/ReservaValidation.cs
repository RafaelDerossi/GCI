using CondominioApp.ReservaAreaComum.Aplication.Commands;
using FluentValidation;
using System;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class ReservaValidation<T> : AbstractValidator<T> where T : ReservaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateAreaComumId()
        {
            RuleFor(c => c.AreaComumId)
                .NotEqual(Guid.Empty);
        }
       
        protected void ValidateObservacao()
        {
            RuleFor(c => c.Observacao)
                .Length(0, 240).WithMessage("Observação deve ter no máximo de 240 caracteres!");
        }

        protected void ValidateUnidadeId()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNumeroUnidade()
        {
            RuleFor(c => c.NumeroUnidade)
                .NotEmpty().WithMessage("Número da Unidade não pode estar vazio!")
                .Length(2, 200).WithMessage("Número da Unidade deve ter mais de 2 caracteres!");
        }

        protected void ValidateAndarUnidade()
        {
            RuleFor(c => c.AndarUnidade)
                .NotEmpty().WithMessage("Andar da Unidade não pode estar vazio!")
                .Length(2, 200).WithMessage("Andar da Unidade deve ter mais de 2 caracteres!");
        }

        protected void ValidateDescricaoGrupoUnidade()
        {
            RuleFor(c => c.NumeroUnidade)
                .NotEmpty().WithMessage("Descrição do Grupo da Unidade não pode estar vazio!")
                .Length(2, 200).WithMessage("Descrição do Grupo da Unidade deve ter mais de 2 caracteres!");
        }

        protected void ValidateUsuarioId()
        {
            RuleFor(c => c.UsuarioId)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNomeUsuario()
        {
            RuleFor(c => c.NumeroUnidade)
                .NotEmpty().WithMessage("Nome do Usuario não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do Usuario deve ter mais de 2 caracteres!");
        }

        protected void ValidateDataDeRealizacao()
        {
            RuleFor(c => c.DataDeRealizacao)
                .NotEmpty().WithMessage("Data de Realização não pode estar vazio!");
        }

        protected void ValidateHoraInicio()
        {
            RuleFor(c => c.HoraInicio)
                .NotEmpty().WithMessage("Hora Inicio não pode estar vazio!")
                .NotEmpty().WithMessage("Hora Inicio não pode estar nulo!")
                .Length(5).WithMessage("Hora Inicio deve ter 5 caracteres!")
                .Matches("[012][0-9]:[0-5][0-9]").WithMessage("Hora Inicio inválida!");
        }

        protected void ValidateHoraFim()
        {
            RuleFor(c => c.HoraFim)
                .NotEmpty().WithMessage("Hora Fim não pode estar vazio!")
                .NotEmpty().WithMessage("Hora Fim não pode estar nulo!")
                .Length(5).WithMessage("Hora Fim deve ter 5 caracteres!")
                .Matches("[012][0-9]:[0-5][0-9]").WithMessage("Hora Fim inválida!");
        }

        protected void ValidateAtiva()
        {
            RuleFor(c => c.Ativa)
                .NotNull().WithMessage("'Ativa' não pode estar vazio!");
        }

        protected void ValidatePreco()
        {
            RuleFor(c => c.Preco)
                .NotNull().WithMessage("Preço não pode estar vazio!");
        }

        protected void ValidateEstaNaFila()
        {
            RuleFor(c => c.EstaNaFila)
                .NotNull().WithMessage("'Esta na Fila' não pode estar vazio!");
        }

        protected void ValidateJustificativa()
        {
            RuleFor(c => c.Justificativa)
                .Length(0, 200).WithMessage("Justificativa deve ter no máximo 200 caracteres!");
        }

        protected void ValidateOrigem()
        {
            RuleFor(c => c.Origem)
                .Length(0, 200).WithMessage("Origem deve ter no máximo 200 caracteres!");
        }

        protected void ValidateReservadoPelaAdministracao()
        {
            RuleFor(c => c.ReservadoPelaAdministracao)
                .NotNull().WithMessage("'Reservado pela Administracao' não pode estar vazio!");
        }
    }
}
