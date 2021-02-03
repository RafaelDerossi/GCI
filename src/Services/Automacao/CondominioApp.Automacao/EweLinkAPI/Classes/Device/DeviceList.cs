using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CondominioApp.Automacao.EwelinkNet.Classes
{

    public class DeviceList
    {
        public int error { get; set; }
        public List<Device> devicelist { get; set; }
    }
}
