using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using EwelinkNet.Classes;
using EwelinkNet.Constants;
using EwelinkNet.Helpers;


namespace EwelinkNet.Payloads
{
    internal class WsCredentialsPayload
    {
        public string Action { get; internal set; }
        public string UserAgent { get; internal set; }
        public string Version { get; internal set; }
        public string Nonce { get; internal set; }
        public string ApkVesrion { get; internal set; }
        public string Os { get; internal set; }
        public string At { get; internal set; }
        public string Apikey { get; internal set; }
        public string Ts { get; internal set; }
        public string Model { get; internal set; }
        public string RomVersion { get; internal set; }
        public string Sequence { get; internal set; }


        internal WsCredentialsPayload(string accessToken, string apiKey)
        {
            var (timestamp, sequence) = EwelinkHelper.MakeSequence();

            Action = "userOnline";
            UserAgent = "app";
            Version = AppData.VERSION;
            Nonce = EwelinkHelper.MakeNonce();
            ApkVesrion = AppData.APK_VERSION;
            Os = AppData.OS;
            At = accessToken;
            Apikey = apiKey;
            Ts = timestamp;
            Model = AppData.MODEL;
            RomVersion = AppData.ROM_VERSION;
            Sequence = sequence;
        }
    }
}
