using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.Core.Messages;
using CondominioApp.Usuarios.App.Models;
using MediatR;

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
