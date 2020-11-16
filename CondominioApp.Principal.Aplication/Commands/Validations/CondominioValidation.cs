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
            RuleFor(c => c.Cnpj.numero)
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
            RuleFor(c => c.Portaria)
                  .NotNull()                
                  .WithMessage("Portaria não pode estar vazio!");
        }
        protected void ValidatePortariaMorador()
        {
            RuleFor(c => c.PortariaMorador)
                  .NotNull()                 
                  .WithMessage("Portaria Morador não pode estar vazio!");
        }
        protected void ValidateClassificado()
        {
            RuleFor(c => c.Classificado)
                  .NotNull()                 
                  .WithMessage("Classificado não pode estar vazio!");
        }
        protected void ValidateClassificadoMorador()
        {
            RuleFor(c => c.ClassificadoMorador)
                  .NotNull()                  
                  .WithMessage("Classificado Morador não pode estar vazio!");
        }
        protected void ValidateMural()
        {
            RuleFor(c => c.Mural)
                .NotNull()
                .WithMessage("Mural não pode estar vazio!");
        }
        protected void ValidateMuralMorador()
        {
            RuleFor(c => c.MuralMorador)
                  .NotNull()                
                  .WithMessage("Mural Morador não pode estar vazio!");
        }
        protected void ValidateChat()
        {
            RuleFor(c => c.Chat)
                  .NotNull()                  
                  .WithMessage("Chat não pode estar vazio!");
        }
        protected void ValidateChatMorador()
        {
            RuleFor(c => c.ChatMorador)
                .NotNull()
                .WithMessage("Chat Morador não pode estar vazio!");
        }
        protected void ValidateReserva()
        {
            RuleFor(c => c.Reserva)
                  .NotNull()                 
                  .WithMessage("Reserva não pode estar vazio!");
        }
        protected void ValidateReservaNaPortaria()
        {
            RuleFor(c => c.ReservaNaPortaria)
                  .NotNull()                 
                  .WithMessage("Reserva na Portaria não pode estar vazio!");
        }
        protected void ValidateOcorrencia()
        {
            RuleFor(c => c.Ocorrencia)
                  .NotNull()                  
                  .WithMessage("Ocorrencia não pode estar vazio!");
        }
        protected void ValidateOcorrenciaMorador()
        {
            RuleFor(c => c.OcorrenciaMorador)
                  .NotNull()                
                  .WithMessage("Ocorrencia Morador não pode estar vazio!");
        }
        protected void ValidateCorrespondencia()
        {
            RuleFor(c => c.Correspondencia)
                  .NotNull()                 
                  .WithMessage("Correspondencia não pode estar vazio!");
        }
        protected void ValidateCorrespondenciaNaPortaria()
        {
            RuleFor(c => c.CorrespondenciaNaPortaria)
                  .NotNull()                  
                  .WithMessage("Correspondencia na Portaria não pode estar vazio!");
        }
       


    }
}
