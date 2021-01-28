using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Usuarios.App.Aplication.Events
{
    public class UsuarioEventHandler :
        INotificationHandler<MoradorCadastradoEvent>
    {
        public async Task Handle(MoradorCadastradoEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
