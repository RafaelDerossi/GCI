using System;

namespace CondominioApp.NotificacaoPush.App.OneSignalApps
{
    public class SindicoOneSignalApp : IOneSignalApp
    {
        public Guid AppId { get; private set; }

        public string ApiKey { get; private set; }

        public SindicoOneSignalApp()
        {
            AppId = Guid.Parse("a5f256d5-e152-47f1-b81d-8cad9189e6ac");
            ApiKey = "NTJjMTQwMDAtNDAwMy00MWM2LThhZGEtNjM2NDZmOGQ4ZjE3";
        }
    }
}
