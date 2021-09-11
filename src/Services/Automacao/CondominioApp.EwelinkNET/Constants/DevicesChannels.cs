using EwelinkNet.Helpers.Extensions;
using System.Collections.Generic;

namespace EwelinkNet.Constants
{
    internal class DeviceChannels
    {
        #pragma warning disable CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
        private static readonly Dictionary<string?, int?> data = new Dictionary<string?, int?> {
        #pragma warning restore CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
            {"SOCKET", 1},
            {"SWITCH_CHANGE", 1},
            {"GSM_UNLIMIT_SOCKET", 1},
            {"SWITCH", 1},
            {"THERMOSTAT", 1},
            {"SOCKET_POWER", 1},
            {"GSM_SOCKET", 1},
            {"POWER_DETECTION_SOCKET", 1},
            {"SOCKET_2", 2},
            {"GSM_SOCKET_2", 2},
            {"SWITCH_2", 2},
            {"SOCKET_3", 3},
            {"GSM_SOCKET_3", 3},
            {"SWITCH_3", 3},
            {"SOCKET_4", 4},
            {"GSM_SOCKET_4", 4},
            {"SWITCH_4", 4},
            {"CUN_YOU_DOOR", 4}
        };

        internal static int? GetDeviceChannelsByName(string deviceName) => data.GetOrDefault(deviceName);
    }
}