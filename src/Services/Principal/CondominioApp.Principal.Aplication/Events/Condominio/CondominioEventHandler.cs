using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using MediatR;

namespace CondominioApp.Principal.Aplication.Events
{
    public class CondominioEventHandler :
        INotificationHandler<CondominioCadastradoEvent>
    {
        public async Task Handle(CondominioCadastradoEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
