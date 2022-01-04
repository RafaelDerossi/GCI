using System.Threading.Tasks;
using GCI.Core.Messages.CommonMessages;
using FluentValidation.Results;

namespace GCI.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : DomainEvent;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
