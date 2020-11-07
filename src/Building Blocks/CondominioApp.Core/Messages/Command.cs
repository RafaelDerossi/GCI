using System;
using FluentValidation.Results;
using MediatR;

namespace CondominioApp.Core.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EstaValido()
        {
            return ValidationResult.IsValid;
        }
    }
}