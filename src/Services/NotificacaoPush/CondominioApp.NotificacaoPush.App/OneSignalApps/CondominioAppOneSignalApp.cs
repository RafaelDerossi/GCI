using System;

namespace CondominioApp.NotificacaoPush.App.OneSignalApps
{
    public class CondominioAppOneSignalApp : IOneSignalApp
    {
        public Guid AppId { get; private set; }

        public string ApiKey { get; private set; }

        public CondominioAppOneSignalApp()
        {
            AppId  = Guid.Parse("9d9f84c1-f074-4976-84e6-88562d5343b7");
            ApiKey = "Y2EwMzhiOWYtMWRlMi00Njg4LWFjZDctOTE1OWFkOTViN2Fl";
        }
    }
}
