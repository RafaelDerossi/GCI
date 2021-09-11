using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using MediatR;


namespace CondominioApp.Enquetes.App.Aplication.Events
{
    public class EnqueteEventHandler : EventHandler, 
        INotificationHandler<EnqueteCadastradaEvent>
    {

        public async Task Handle(EnqueteCadastradaEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
