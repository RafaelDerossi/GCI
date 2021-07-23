using FluentValidation;
using System;

namespace CondominioApp.Principal.Aplication.Commands.Validations
{
    public abstract class CondominioValidation<T> : AbstractValidator<T> where T : CondominioCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.CondominioId)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateCNPJ()
        {
            RuleFor(c => c.Cnpj)
                  .NotNull()
                  .NotEmpty()                  
                  .WithMessage("CNPJ não pode estar vazio!");
        }
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do condominio não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do condominio deve ter mais de 2 caracteres!");
        }


        protected void ValidatePortaria()
        {
            RuleFor(c => c.PortariaAtivada)
                  .NotNull()                
                  .WithMessage("Portaria não pode estar vazio!");
        }
        protected void ValidatePortariaMorador()
        {
            RuleFor(c => c.PortariaParaMoradorAtivada)
                  .NotNull()                 
                  .WithMessage("Portaria Morador não pode estar vazio!");
        }
        protected void ValidateClassificado()
        {
            RuleFor(c => c.ClassificadoAtivado)
                  .NotNull()                 
                  .WithMessage("Classificado não pode estar vazio!");
        }
        protected void ValidateClassificadoMorador()
        {
            RuleFor(c => c.ClassificadoParaMoradorAtivado)
                  .NotNull()                  
                  .WithMessage("Classificado Morador não pode estar vazio!");
        }
        protected void ValidateMural()
        {
            RuleFor(c => c.MuralAtivado)
                .NotNull()
                .WithMessage("Mural não pode estar vazio!");
        }
        protected void ValidateMuralMorador()
        {
            RuleFor(c => c.MuralParaMoradorAtivado)
                  .NotNull()                
                  .WithMessage("Mural Morador não pode estar vazio!");
        }
        protected void ValidateChat()
        {
            RuleFor(c => c.ChatAtivado)
                  .NotNull()                  
                  .WithMessage("Chat não pode estar vazio!");
        }
        protected void ValidateChatMorador()
        {
            RuleFor(c => c.ChatParaMoradorAtivado)
                .NotNull()
                .WithMessage("Chat Morador não pode estar vazio!");
        }
        protected void ValidateReserva()
        {
            RuleFor(c => c.ReservaAtivada)
                  .NotNull()                 
                  .WithMessage("Reserva não pode estar vazio!");
        }
        protected void ValidateReservaNaPortaria()
        {
            RuleFor(c => c.ReservaNaPortariaAtivada)
                  .NotNull()                 
                  .WithMessage("Reserva na Portaria não pode estar vazio!");
        }
        protected void ValidateOcorrencia()
        {
            RuleFor(c => c.OcorrenciaAtivada)
                  .NotNull()                  
                  .WithMessage("Ocorrencia não pode estar vazio!");
        }
        protected void ValidateOcorrenciaMorador()
        {
            RuleFor(c => c.OcorrenciaParaMoradorAtivada)
                  .NotNull()                
                  .WithMessage("Ocorrencia Morador não pode estar vazio!");
        }
        protected void ValidateCorrespondencia()
        {
            RuleFor(c => c.CorrespondenciaAtivada)
                  .NotNull()                 
                  .WithMessage("Correspondencia não pode estar vazio!");
        }
        protected void ValidateCorrespondenciaNaPortaria()
        {
            RuleFor(c => c.CorrespondenciaNaPortariaAtivada)
                  .NotNull()                  
                  .WithMessage("Correspondencia na Portaria não pode estar vazio!");
        }


        protected void ValidateFuncionarioIdDoSindico()
        {
            RuleFor(c => c.FuncionarioIdDoSindico)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNomeDoSindico()
        {
            RuleFor(c => c.NomeDoSindico)
                .NotEmpty().WithMessage("Nome do Síndico não pode estar vazio!")
                .Length(2, 200).WithMessage("Nome do Síndico deve ter mais de 2 caracteres!");
        }
    }
}
