using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AMT.ReportingInterfaces.WMI
{
  public class LogicalDiskInfo
    {

      public String TimeStamp = String.Empty;

      [DisplayName("SystemName")]
      public string SystemName { get; set; }

      //[DisplayName("VolumeName")]
      //public string VolumeName { get; set; }

      [DisplayName("Name")]
      public string Name { get; set; }

      [DisplayName("Size")]
      public string Size { get; set; }

      [DisplayName("FreeSpace")]
      public string FreeSpace { get; set; }

      [DisplayName("FileSystem")]
      public string FileSystem { get; set; }

      [DisplayName("Caption")]
      public string Caption { get; set; }

      [DisplayName("Compressed")]
      public string Compressed { get; set; }

      [DisplayName("Description")]
      public string Description { get; set; }

      [DisplayName("DeviceID")]
      public string DeviceID { get; set; }

      [DisplayName("DriveType")]
      public string DriveType { get; set; }

      [DisplayName("MediaType")]
      public string MediaType { get; set; }

      [DisplayName("SupportsFileBasedCompression")]
      public string SupportsFileBasedCompression { get; set; }

      [DisplayName("VolumeSerialNumber")]
      public string VolumeSerialNumber { get; set; }

    }
}
