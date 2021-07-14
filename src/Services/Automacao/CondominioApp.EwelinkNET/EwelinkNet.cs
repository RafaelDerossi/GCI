using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EwelinkNet.Classes;
using EwelinkNet.Helpers.Extensions;
using System.Dynamic;
using EwelinkNet.API.Responses;
using EwelinkNet.Classes.Events;
using WebSocketSharp;
using System.Linq;
using System.Threading;

namespace EwelinkNet
{
    public class Ewelink
    {
        public event EventHandler<EvendDeviceUpdate> OnDeviceChanged;

        public string region { get; set; } = "us";
        public string email { get; set; }
        public string password { get; set; }
        public string at { get; set; }
        public string apikey { get; set; }



        [JsonIgnore]
        public ArpTable Arptable { get; set; } = new ArpTable();

        [JsonIgnore]
        internal Credentials Credentials { get; private set; }

        [JsonIgnore]
        public Device[] Devices { get; private set; }

        [JsonIgnore]
        internal API.WebSocket webSocket = new API.WebSocket();

        [JsonIgnore]
        internal Guid CondominioId { get; private set; }

        [JsonIgnore]
        internal string pasta = "wwwroot/ewelink/";



        public Ewelink(string email, string password, Guid condominioId, string region = "us")
        {
            this.email = email;
            this.password = password;
            this.region = region;
            CondominioId = condominioId;

            RestoreCredenditalsFromFile();

            RestoreDevicesFromFile();            
        }      

        public async Task GetCredentials()
        {
            var url = Constants.URLs.GetApiUrl(region);

            var response = await API.Rest.GetCredentials(url, email, password);
            Credentials = JsonConvert.DeserializeObject<Credentials>(response);

            if (Credentials.user == null)
                return;

            at = Credentials.at;            
            apikey = at = Credentials.user.apikey;

            StoreCredenditalsToFile();
        }

        public async Task<string> GetRegion()
        {
            var url = Constants.URLs.GetApiUrl(region);

            var response = await API.Rest.GetCredentials(url, email, password);
            dynamic credentials = JsonConvert.DeserializeObject<ExpandoObject>(response);
            region = credentials.region;
            return region;
        }

        public void StoreCredenditalsToFile()        
        {
            if (!System.IO.Directory.Exists(pasta))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(pasta);
                }
                catch (Exception)
                {
                }
            }

            var filename = $"{pasta}credentials_{CondominioId}.json";
            System.IO.File.WriteAllText(filename, Credentials.AsJson()); 
        }

        public void RestoreCredenditalsFromFile()
        {
            var filename = $"{pasta}credentials_{CondominioId}.json";
            if (System.IO.File.Exists(filename))
            {
                Credentials = System.IO.File.ReadAllText(filename).FromJson<Credentials>();
                if (Credentials != null)
                {
                    at = Credentials.at;                    
                    apikey = Credentials.user.apikey;
                }
            }            
        }

        public void StoreDevicesToFile()
        {
            var filename = $"{pasta}devices_{CondominioId}.json";
            System.IO.File.WriteAllText(filename, Devices.AsJson());
        }

        public void RestoreDevicesFromFile()
        {
            var filename = $"{pasta}devices_{CondominioId}.json";
            if (System.IO.File.Exists(filename))
            {
                CreateDevices(System.IO.File.ReadAllText(filename).FromJson<Device[]>());
            }                
        }
        

        public void RestoreArpTableFromFile(string filename = "arp-table.json") => Arptable.RestoreFromFile(filename);


        public async Task GetDevices()
        {
            var url = Constants.URLs.GetApiUrl(region);

            var response = await API.Rest.GetDevices(url, Credentials.at);            

            CreateDevices(response);

            StoreDevicesToFile();
        }
        
        private void CreateDevices(string json)
        {
            try
            {
                CreateDevices(JsonConvert.DeserializeObject<DeviceList>(json).devicelist.ToArray());
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public void ToggleDevice(string deviceId)
        {
            var deviceSwitch = Devices.First(x => x.deviceid == deviceId) as SwitchDevice;
            var device = Devices.First(x => x.deviceid == deviceId);

            var state = device.deviceStatus;
            if (state == null)
            {
                state = deviceSwitch.GetState();                
            }

            var pulse = device.GetParameter("pulse");

            if (state == "on")
            {
                deviceSwitch.TurnOff();

                if (pulse == "off")
                {
                    device.deviceStatus = "off";
                }

                Thread.Sleep(500);                
            }
            else
            {
                deviceSwitch.TurnOn();

                if (pulse == "off")
                {
                    device.deviceStatus = "on";
                }

                Thread.Sleep(500);                
            }

            StoreDevicesToFile();
        }



        private Dictionary<string, Device> deviceCache = new Dictionary<string, Device>();

        private void CreateDevices(Device[] devices)
        {
            Devices = devices.Select(x => DeviceFactory.CreateDevice(this, x)).ToArray();
            deviceCache = Devices.ToDictionary(x => x.deviceid);
        }

        public void OpenWebSocket()
        {
            if (webSocket.IsConnected) return;
            webSocket.Connect(Credentials.at, Devices[0].apikey, Credentials.region);
            webSocket.OnMessage += handleWebsocketResponse;
        }

        private void handleWebsocketResponse(object sender, EventWebsocketMessage e)
        {
            if (!(e.Message is WsUpdateResponse response)) return;

            if (deviceCache.ContainsKey(response.deviceid))
            {
                ExpandoHelpers.Map(response.@params, deviceCache[response.deviceid].@params);
                OnDeviceChanged.Emit(e, new EvendDeviceUpdate() { Device = deviceCache[response.deviceid] });
            }
        }

        public void CloseWebSocket()
        {
            if (!webSocket.IsConnected) return;
            webSocket.OnMessage -= handleWebsocketResponse;
            webSocket.Disconnect();
        }
    }
}
