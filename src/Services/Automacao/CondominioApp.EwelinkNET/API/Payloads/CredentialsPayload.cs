using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using EwelinkNet.Constants;
using EwelinkNet.Helpers;
using Newtonsoft.Json;

namespace EwelinkNet.Payloads
{
    internal class CredentialsPayload
    {
        public string Email { get; internal set; }
        public string Password { get; internal set;}
        public string Version { get; internal set; }
        public string Ts { get; internal set; }
        public string Nonce { get; internal set; }
        public string Appid { get; internal set; }
        public string Imei { get; internal set; }
        public string Os { get; internal set; }
        public string Model { get; internal set;}
        public string RomVersion { get; internal set; }
        public string AppVersion { get; internal set; }


        internal CredentialsPayload(string email, string password)
        {
            this.Email = email;
            this.Password = password;
            Version = AppData.VERSION;
            Ts = EwelinkHelper.MakeTimestamp();
            Nonce = EwelinkHelper.MakeNonce();
            Os = AppData.OS;
            Appid = AppData.APP_ID;
            Imei = EwelinkHelper.MakeFakeImei();
            Model = AppData.MODEL;
            RomVersion = AppData.ROM_VERSION;
            AppVersion = AppData.APP_VERSION;
        }

    }
}
