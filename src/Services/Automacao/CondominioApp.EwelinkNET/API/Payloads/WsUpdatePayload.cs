using EwelinkNet.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EwelinkNet.Payloads
{
    public class WsUpdatePayload
    {
        public string Action { get; internal set; }
        public string UserAgent { get; internal set; }

        public string Deviceid { get; internal set; }

        public string Apikey { get; internal set; }
        public string SelfApikey { get; internal set; }

        public dynamic @params { get; internal set; } = new ExpandoObject();

        public string Sequence { get; internal set; }

        internal WsUpdatePayload(string deviceId, string apiKey, object @params)
        {
            var (_, sequence) = EwelinkHelper.MakeSequence();

            Action = "update";
            UserAgent = "app";
            Deviceid = deviceId;
            Apikey = apiKey;
            SelfApikey = apiKey;
            this.@params = @params;
            Sequence = sequence;
        }
    }
}
