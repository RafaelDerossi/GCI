using System;
using CondominioApp.Core.Messages;
using FluentValidation;

namespace CondominioAppPreCadastro.App.Aplication.Commands
{
    public class TransferirCondominioCommand : Command
    {
        public Guid LeadId { get; private set; }
        public Guid CondominioId { get; private set; }

        public TransferirCondominioCommand(Guid leadId, Guid condominioId)
        {
            LeadId = leadId;
            CondominioId = condominioId;
        }


        public override bool EstaValido()
        {
           var result = new TransferirCondominioValidation().Validate(this);
           return result.IsValid;
        }

        public class TransferirCondominioValidation : AbstractValidator<TransferirCondominioCommand>
        {
            public TransferirCondominioValidation()
            {
                RuleFor(c => c.CondominioId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do condominio deve estar preenchido!");

                RuleFor(c => c.LeadId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do lead deve estar preenchido!");
            }
        }

    }
}