using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioApp.OneSignal
{
   public abstract class RecursoBase
    {
        protected RestClient RestClient { get; set; }

        protected string ApiKey { get; set; }

        protected RecursoBase(string apiKey, string apiUri)
        {
            ApiKey = apiKey;
            RestClient = new RestClient(apiUri);
        }
    }
}
