﻿using System;
using System.Collections.Generic;
using System.Text;
using EwelinkNet.Helpers.Extensions;


namespace EwelinkNet.Constants
{
    internal static class DevicesSwitchName
    {
        #pragma warning disable CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
        private static readonly Dictionary<string?, string?> data = new Dictionary<string?, string?> {
        #pragma warning restore CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
            {"SWITCH_CHANGE", "switch"},
            {"SOCKET", "switch"},
            {"THERMOSTAT", "switch"},
            {"SWITCH", "switch"},
            {"SOCKET_POWER", "switch"},
            {"HUMIDIFIER", "switch"},
            {"GSM_SOCKET", "switch"},
            {"GSM_UNLIMIT_SOCKET", "switch"},
            {"BJ_THERMOSTAT", "switch"},
            {"AROMATHERAPY", "switch"},
            {"POWER_DETECTION_SOCKET", "switch"},


            {"DOUBLE_COLOR_DEMO_LIGHT", "state"},
            {"DOWN_CEILING_LIGHT", "state"},
            {"RGB_BALL_LIGHT", "state"},
            {"RGB_BALL_LIGHT_4", "state"},
            {"COLD_WARM_LED", "state"},
            {"MONOCHROMATIC_BALL_LIGHT", "state"},
            {"YI_GE_ER_LAMP", "state"},

            {"SOCKET_4", "switches"},
            {"SWITCH_4", "switches"},
            {"GSM_SOCKET_4", "switches"},
            {"SOCKET_3", "switches"},
            {"SWITCH_3", "switches"},
            {"GSM_SOCKET_3", "switches"},
            {"SOCKET_2", "switches"},
            {"SWITCH_2", "switches"},
            {"GSM_SOCKET_2", "switches"},
            {"CUN_YOU_DOOR", "switches"},
            {"FAN_LIGHT", "switches"},
            {"GSM_SOCKET_NO_FLOW", "switches"},
            {"GSM_SOCKET_2_NO_FLOW", "switches"},
            {"GSM_SOCKET_3_NO_FLOW", "switches"},
            {"GSM_SOCKET_4_NO_FLOW", "switches"},
            {"SINGLE_SOCKET_MULTIPLE", "switches"},
            {"SINGLE_SWITCH_MULTIPLE", "switches"},
            {"ZIGBEE_SWITCH_2", "switches"},
            {"ZIGBEE_SWITCH_3", "switches"},
            {"ZIGBEE_SWITCH_4", "switches"},

            {"THREE_GEAR_FAN", "fan"},
            {"SENSORS_CENTER", "state"},
            {"NEST_THERMOSTAT", "state"},
            {"RF_BRIDGE", "state"},
            {"GSM_RFBridge", "state"},
            {"DOORBELL_RFBRIDGE", "state"},
            {"ZIGBEE_DOOR_AND_WINDOW_SENSOR", "lock"},
            {"ZIGBEE_MOBILE_SENSOR", "motion"},
            {"ZIGBEE_WATER_SENSOR", "water"},
            {"ZIGBEE_WIRELESS_SWITCH", "key"},
            {"ZIGBEE_INFRARED_GATEWAY", "key"},

        };

        internal static string GetDeviceSwitchByName(string deviceName) => data.GetOrDefault(deviceName);
    }
}
