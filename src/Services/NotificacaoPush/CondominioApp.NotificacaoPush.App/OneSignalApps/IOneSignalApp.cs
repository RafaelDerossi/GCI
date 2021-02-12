using System;

namespace CondominioApp.NotificacaoPush.App.OneSignalApps
{
   public interface IOneSignalApp
    {
        Guid AppId { get; }

        string ApiKey { get; }
    }
}
