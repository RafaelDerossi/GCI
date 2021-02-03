using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.Automacao.EwelinkNet.Classes.Events
{
    public class EventWebsocketMessage : EventArgs
    {

        public object Message { get; set; }
    }
}
