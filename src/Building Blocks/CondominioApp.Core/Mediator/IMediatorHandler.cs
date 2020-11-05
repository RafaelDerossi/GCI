using System.Threading.Tasks;
using CondominioApp.Core.Messages;

namespace CondominioApp.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
