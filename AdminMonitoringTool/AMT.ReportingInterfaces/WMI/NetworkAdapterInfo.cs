using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
   public  class NetworkAdapterInfo
    {

        public String TimeStamp = String.Empty;

        [DisplayName("AdapterType")]
        public string AdapterType { get; set; }

        [DisplayName("AdapterTypeID")]
        public string AdapterTypeID { get; set; }

        [DisplayName("Caption")]
        public string Caption { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("DeviceID")]
        public string DeviceID { get; set; }

        [DisplayName("Installed")]
        public string Installed { get; set; }

        [DisplayName("MACAddress")]
        public string MACAddress { get; set; }

        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("NetConnectionID")]
        public string NetConnectionID { get; set; }

        [DisplayName("NetConnectionStatus")]
        public string NetConnectionStatus { get; set; }

        [DisplayName("NetEnabled")]
        public string NetEnabled { get; set; }

        [DisplayName("PhysicalAdapter")]
        public string PhysicalAdapter { get; set; }

        [DisplayName("PNPDeviceID")]
        public string PNPDeviceID { get; set; }

        [DisplayName("PowerManagementSupported")]
        public string PowerManagementSupported { get; set; }

        [DisplayName("ProductName")]
        public string ProductName { get; set; }

        [DisplayName("ServiceName")]
        public string ServiceName { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("SystemName")]
        public string SystemName { get; set; }

        [DisplayName("TimeOfLastReset")]
        public string TimeOfLastReset { get; set; }

        [DisplayName("Guid")]
        public string Guid { get; set; }
    }
}
