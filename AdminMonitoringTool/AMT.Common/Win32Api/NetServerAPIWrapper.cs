using AMT.Logger;
using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace AMT.Common.Win32Api
    {
        public  class NetServerAPIWrapper
        {
             const uint ERROR_SUCCESS = 0;
             const uint ERROR_MORE_DATA = 234;


             enum SV_101_TYPES : uint
            {
                SV_TYPE_WORKSTATION = 0x00000001,
                SV_TYPE_SERVER = 0x00000002,
                SV_TYPE_SQLSERVER = 0x00000004,
                SV_TYPE_DOMAIN_CTRL = 0x00000008,
                SV_TYPE_DOMAIN_BAKCTRL = 0x00000010,
                SV_TYPE_TIME_SOURCE = 0x00000020,
                SV_TYPE_AFP = 0x00000040,
                SV_TYPE_NOVELL = 0x00000080,
                SV_TYPE_DOMAIN_MEMBER = 0x00000100,
                SV_TYPE_PRINTQ_SERVER = 0x00000200,
                SV_TYPE_DIALIN_SERVER = 0x00000400,
                SV_TYPE_XENIX_SERVER = 0x00000800,
                SV_TYPE_SERVER_UNIX = 0x00000800,
                SV_TYPE_NT = 0x00001000,
                SV_TYPE_WFW = 0x00002000,
                SV_TYPE_SERVER_MFPN = 0x00004000,
                SV_TYPE_SERVER_NT = 0x00008000,
                SV_TYPE_POTENTIAL_BROWSER = 0x00010000,
                SV_TYPE_BACKUP_BROWSER = 0x00020000,
                SV_TYPE_MASTER_BROWSER = 0x00040000,
                SV_TYPE_DOMAIN_MASTER = 0x00080000,
                SV_TYPE_SERVER_OSF = 0x00100000,
                SV_TYPE_SERVER_VMS = 0x00200000,
                SV_TYPE_WINDOWS = 0x00400000,
                SV_TYPE_DFS = 0x00800000,
                SV_TYPE_CLUSTER_NT = 0x01000000,
                SV_TYPE_TERMINALSERVER = 0x02000000,
                SV_TYPE_CLUSTER_VS_NT = 0x04000000,
                SV_TYPE_DCE = 0x10000000,
                SV_TYPE_ALTERNATE_XPORT = 0x20000000,
                SV_TYPE_LOCAL_LIST_ONLY = 0x40000000,
                SV_TYPE_DOMAIN_ENUM = 0x80000000,
                SV_TYPE_ALL = 0xFFFFFFFF
            };





           [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
             struct SERVER_INFO_101
            {
                [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
                public UInt32 sv101_platform_id;
                [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
                public string sv101_name;

                [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
                public UInt32 sv101_version_major;
                [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
                public UInt32 sv101_version_minor;
                [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
                public UInt32 sv101_type;
                [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
                public string sv101_comment;
            };
              enum PLATFORM_ID
            {
                PLATFORM_ID_DOS = 300,
                PLATFORM_ID_OS2 = 400,
                PLATFORM_ID_NT = 500,
                PLATFORM_ID_OSF = 600,
                PLATFORM_ID_VMS = 700
            }


            [DllImport("netapi32.dll", EntryPoint = "NetServerEnum")]
            private  static  extern int NetServerEnum (
            [MarshalAs(UnmanagedType.LPWStr)]string servername,
            int level,
            out IntPtr bufptr,
            int prefmaxlen,
            ref int entriesread,
            ref int totalentries,
            SV_101_TYPES servertype,
            [MarshalAs(UnmanagedType.LPWStr)]string domain,
            IntPtr resume_handle);


            public  List<DomainInfo> GetNetworkList ()
            {
                int entriesread = 0, totalentries = 0;
                List<DomainInfo> NetworkList = new List<DomainInfo>();

                try
                {
                    do
                    {
                        // Buffer to store the available servers
                        // Filled by the NetServerEnum function
                        IntPtr buf = new IntPtr();

                        NetServerAPIWrapper.SERVER_INFO_101 server;
                        int returnResult = NetServerAPIWrapper.NetServerEnum(null, 101, out buf, -1,
                             ref entriesread, ref totalentries,
                              NetServerAPIWrapper.SV_101_TYPES.SV_TYPE_DOMAIN_ENUM, null, IntPtr.Zero);

                        // if the function returned any data, fill the tree view
                        if (returnResult == NetServerAPIWrapper.ERROR_SUCCESS ||
                             returnResult == NetServerAPIWrapper.ERROR_MORE_DATA ||
                             entriesread > 0)
                        {
                            IntPtr ptr = buf;

                            for (int domainIndex = 0; domainIndex < entriesread; domainIndex++)
                            {
                                // cast pointer to a SERVER_INFO_101 structure
                                server = (NetServerAPIWrapper.SERVER_INFO_101)Marshal.PtrToStructure(ptr, typeof(NetServerAPIWrapper.SERVER_INFO_101));

                                //Cast the pointer to a ulong so this addition will work on 32-bit or 64-bit systems.
                                ptr = (IntPtr)((ulong)ptr + (ulong)Marshal.SizeOf(server));




                                NetworkList.Add(new DomainInfo() { DomainName = server.sv101_name, Severs = GetServerList(server.sv101_name) });
                            }
                        }

                        // free the buffer 
                        NetAPICommon.NetApiBufferFree(buf);

                    }
                    while
                    (
                    entriesread < totalentries &&
                    entriesread != 0
                    );


                    if (NetworkList.Count == 0)
                    {

                        NetworkList.Add(new DomainInfo() { DomainName ="localhost" , Severs = new List<ServerInfo>() { new ServerInfo() { ServerName = Environment.MachineName, MajorVersion = (uint)Environment.OSVersion.Version.Major, MinorVersion = (uint)Environment.OSVersion.Version.Minor, PlatformId = (uint)Environment.OSVersion.Platform } } });
                        //foreach (var testItem in new List<String>() { "D1", "D2", "D" })
                        //{
                        //    foreach (var serve in new List<String>() { "Dummy1", "Dummy2", "Dummy3", "Dummy4" })
                        //    {
                        //        NetworkList.Add(new DomainInfo() { DomainName = testItem, Severs = new List<ServerInfo>() { new ServerInfo{ServerName =serve ,ServerType=26 ,MajorVersion =6,MinorVersion =5, PlatformId =6} } });
                        //    }
                        //}

                        //NetworkList.Add(new DomainInfo() { DomainName = "localHost", Severs = new List<ServerInfo>() { new ServerInfo { ServerName = Environment.MachineName, ServerType = 26, MajorVersion = 6, MinorVersion = 5, PlatformId = 6 } } });

                    }

                    


                }

                catch (Exception ex)
                {

                    AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                }

                return NetworkList;
            }

            public  List<ServerInfo> GetServerList (String DomainName)
            {

                List<ServerInfo> serverItems = new List<ServerInfo>();
                int entriesread = 0, totalentries = 0;
                try
                {

                    do
                    {
                        // Buffer to store the available servers
                        // Filled by the NetServerEnum function
                        IntPtr buf = new IntPtr();
                        //NetServerAPIWrapper.SV_101_TYPES.SV_TYPE_WORKSTATION | NetServerAPIWrapper.SV_101_TYPES.SV_TYPE_SERVER
                        NetServerAPIWrapper.SERVER_INFO_101 server;
                        int returnResult = NetServerAPIWrapper.NetServerEnum(null, 101, out buf, -1,
                             ref entriesread, ref totalentries,

                             NetServerAPIWrapper.SV_101_TYPES.SV_TYPE_WORKSTATION |
                               NetServerAPIWrapper.SV_101_TYPES.SV_TYPE_DOMAIN_CTRL | NetServerAPIWrapper.SV_101_TYPES.SV_TYPE_DOMAIN_BAKCTRL


                              , DomainName, IntPtr.Zero);

                        // if the function returned any data, fill the tree view
                        if (returnResult == NetServerAPIWrapper.ERROR_SUCCESS ||
                             returnResult == NetServerAPIWrapper.ERROR_MORE_DATA ||
                             entriesread > 0)
                        {
                            IntPtr ptr = buf;

                            for (int domainIndex = 0; domainIndex < entriesread; domainIndex++)
                            {
                                // cast pointer to a SERVER_INFO_101 structure
                                server = (NetServerAPIWrapper.SERVER_INFO_101)Marshal.PtrToStructure(ptr, typeof(NetServerAPIWrapper.SERVER_INFO_101));

                                //Cast the pointer to a ulong so this addition will work on 32-bit or 64-bit systems.
                                ptr = (IntPtr)((ulong)ptr + (ulong)Marshal.SizeOf(server));




                                serverItems.Add(new ServerInfo()
                                {
                                    ServerName = server.sv101_name,
                                    PlatformId = server.sv101_platform_id,
                                    ServerType = server.sv101_type,
                                    MinorVersion = server.sv101_version_minor,
                                    MajorVersion = server.sv101_version_major,
                                    Comment = server.sv101_comment



                                }


                                );
                            }
                        }

                        // free the buffer 
                        NetAPICommon.NetApiBufferFree(buf);

                    }
                    while
                    (
                    entriesread < totalentries &&
                    entriesread != 0
                    );




                    if (serverItems.Count == 0)
                    {
                        foreach (var testItem in new List<String>() { "Dummy1", "Dummy2", "Dummy3", "Dummy4" })
                        {
                            serverItems.Add(new ServerInfo() { ServerName = DomainName + testItem });
                        }

                    }


                }



                catch (Exception ex)
                {

                    AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                }

                return serverItems;
            }

            public  List<String> GetDomainList ()
            {
                int entriesread = 0, totalentries = 0;
                List<String> NetworkList = new List<String>();

                try
                {
                    do
                    {
                        // Buffer to store the available servers
                        // Filled by the NetServerEnum function
                        IntPtr buf = new IntPtr();

                        NetServerAPIWrapper.SERVER_INFO_101 server;
                        int returnResult = NetServerAPIWrapper.NetServerEnum(null, 101, out buf, -1,
                             ref entriesread, ref totalentries,
                              NetServerAPIWrapper.SV_101_TYPES.SV_TYPE_DOMAIN_ENUM, null, IntPtr.Zero);

                        // if the function returned any data, fill the tree view
                        if (returnResult == NetServerAPIWrapper.ERROR_SUCCESS ||
                             returnResult == NetServerAPIWrapper.ERROR_MORE_DATA ||
                             entriesread > 0)
                        {
                            IntPtr ptr = buf;

                            for (int domainIndex = 0; domainIndex < entriesread; domainIndex++)
                            {
                                // cast pointer to a SERVER_INFO_101 structure
                                server = (NetServerAPIWrapper.SERVER_INFO_101)Marshal.PtrToStructure(ptr, typeof(NetServerAPIWrapper.SERVER_INFO_101));

                                //Cast the pointer to a ulong so this addition will work on 32-bit or 64-bit systems.
                                ptr = (IntPtr)((ulong)ptr + (ulong)Marshal.SizeOf(server));




                                NetworkList.Add(server.sv101_name);
                            }
                        }

                        // free the buffer 
                        NetAPICommon.NetApiBufferFree(buf);

                    }
                    while
                    (
                    entriesread < totalentries &&
                    entriesread != 0
                    );


                }

                catch (Exception ex)
                {

                    AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                }

                return NetworkList;
            }



        }
    }
