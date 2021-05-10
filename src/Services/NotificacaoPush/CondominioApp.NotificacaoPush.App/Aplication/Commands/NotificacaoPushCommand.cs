using CondominioApp.Core.Messages;
using System;

namespace CondominioApp.NotificacaoPush.Commands
{
    public abstract class NotificacaoPushCommand : Command
    {
        public string Titulo { get; protected set; }

        public string Conteudo { get; protected set; }        

        public Guid CondominioId { get; protected set; }        

    }
}
