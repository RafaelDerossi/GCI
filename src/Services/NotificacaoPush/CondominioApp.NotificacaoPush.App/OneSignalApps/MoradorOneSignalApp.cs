using System;

namespace CondominioApp.NotificacaoPush.App.OneSignalApps
{
    public class MoradorOneSignalApp : IOneSignalApp
    {
        public Guid AppId { get; private set; }

        public string ApiKey { get; private set; }

        public MoradorOneSignalApp()
        {
            AppId = Guid.Parse("abb91fa1-6ed1-4bd8-a347-ed62d1c789b9");
            ApiKey = "ZmQ2ZjI1Y2ItZmEzMy00Y2YyLTkzMzItNmFhNjk2MGRhNDM3";
        }
    }
}
