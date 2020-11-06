using FluentValidation.Results;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}