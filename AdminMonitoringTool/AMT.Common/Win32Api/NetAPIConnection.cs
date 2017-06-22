using AMT.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace AMT.Common.Win32Api
{
  public   class NetAPIConnection
    {

        //[DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        //private static  extern int NetWkstaGetInfo ([MarshalAs(UnmanagedType.VBByRefStr)] ref string string_1, int int_0, ref IntPtr intptr_0);

        [DllImport("netapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int NetWkstaGetInfo (string servername, int level, out IntPtr bufptr);

        [DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static  extern long NetApiBufferFree (ref IntPtr intptr_0);

        [DllImport("mpr.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static  extern int WNetAddConnection3 (IntPtr intptr_0, [MarshalAs(UnmanagedType.Struct)] ref NETRESOURCE netresource_0, [MarshalAs(UnmanagedType.VBByRefStr)] ref string string_1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string string_2, int int_0);

        [DllImport("mpr.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int WNetCancelConnection2 ([MarshalAs(UnmanagedType.VBByRefStr)] ref string string_1, int int_0, bool bool_0);


        private struct NETRESOURCE
        {
            public ResourceScope dwScope;
            public ResourceType dwType;
            public ResourceDisplayType dwDisplayType;
            public ResourceUsage dwUsage;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpLocalName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpRemoteName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpComment;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pProvider;
        }

        private enum ResourceDisplayType
        {
            RESOURCEDISPLAYTYPE_GENERIC,
            RESOURCEDISPLAYTYPE_DOMAIN,
            RESOURCEDISPLAYTYPE_SERVER,
            RESOURCEDISPLAYTYPE_SHARE,
            RESOURCEDISPLAYTYPE_FILE,
            RESOURCEDISPLAYTYPE_GROUP,
            RESOURCEDISPLAYTYPE_NETWORK,
            RESOURCEDISPLAYTYPE_ROOT,
            RESOURCEDISPLAYTYPE_SHAREADMIN,
            RESOURCEDISPLAYTYPE_DIRECTORY,
            RESOURCEDISPLAYTYPE_TREE,
            RESOURCEDISPLAYTYPE_NDSCONTAINER,
        }

        private enum ResourceScope
        {
            RESOURCE_CONNECTED = 1,
            RESOURCE_GLOBALNET = 2,
            RESOURCE_REMEMBERED = 3,
            RESOURCE_RECENT = 4,
            RESOURCE_CONTEXT = 5,
        }

        private enum ResourceType
        {
            RESOURCETYPE_ANY,
            RESOURCETYPE_DISK,
            RESOURCETYPE_PRINT,
            RESOURCETYPE_RESERVED,
        }

        private enum ResourceUsage
        {
            RESOURCEUSAGE_CONNECTABLE = 1,
            RESOURCEUSAGE_CONTAINER = 2,
            RESOURCEUSAGE_NOLOCALDEVICE = 4,
            RESOURCEUSAGE_SIBLING = 8,
            RESOURCEUSAGE_ATTACHED = 16,
            RESOURCEUSAGE_ALL = 19,
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WKSTA_INFO_100
        {
            public int platform_id;
            public string computer_name;
            public string lan_group;
            public int ver_major;
            public int ver_minor;
        }



        public static  void CloseConnection (string ServerName, ref int int_0)
        {
            int num;
            try
            {
                string ipcShareName = "\\\\" + ServerName + "\\IPC$";
                num = WNetCancelConnection2(ref ipcShareName, 0, false);
            }
            catch (Exception ex)
            {


                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               
            }
            //int_0 = num;
        }
        private const int RESOURCETYPE_ANY = 0x0;
        private const int CONNECT_INTERACTIVE = 0x8;
        private const int CONNECT_PROMPT = 0x10;


        public static void EstablishConnectionWithPrompt (string machineName, string username, string password, ref int result)
        {
            int num = 0 ;
             string ipcname=String.Empty ;
            try
            {

                NETRESOURCE netresource_0 = new NETRESOURCE();
                ipcname = "\\\\" + machineName + "\\IPC$";
                WNetCancelConnection2(ref ipcname, 0, false);
                netresource_0.dwScope = ResourceScope.RESOURCE_GLOBALNET;
                netresource_0.dwType = ResourceType.RESOURCETYPE_ANY;
                netresource_0.dwDisplayType = ResourceDisplayType.RESOURCEDISPLAYTYPE_SERVER;
                netresource_0.dwUsage = ResourceUsage.RESOURCEUSAGE_CONNECTABLE;
                netresource_0.lpLocalName = (string)null;
                netresource_0.lpRemoteName = ipcname;
                netresource_0.pProvider = (string)null;

                //if (String.IsNullOrEmpty(password) && String.IsNullOrEmpty(username ))
                //    result = WNetAddConnection3((IntPtr)0, ref netresource_0, null, null,);
                //else
                result = WNetAddConnection3((IntPtr)0, ref netresource_0, ref password, ref username, CONNECT_INTERACTIVE | CONNECT_PROMPT);
            }
            catch (Exception ex)
            {

                CloseConnection(ipcname, ref num);
                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
              
            }
            
        }

      //Use this method if you have the password only.
        public static void EstablishConnectionWithOutPrompt (string machineName, string username, string password, ref int result)
        {
            int num = 0;
            string ipcname = String.Empty;
            try
            {

                NETRESOURCE netresource_0 = new NETRESOURCE();
                ipcname = "\\\\" + machineName + "\\IPC$";
                WNetCancelConnection2(ref ipcname, 0, false);
                netresource_0.dwScope = ResourceScope.RESOURCE_GLOBALNET;
                netresource_0.dwType = ResourceType.RESOURCETYPE_ANY;
                netresource_0.dwDisplayType = ResourceDisplayType.RESOURCEDISPLAYTYPE_SERVER;
                netresource_0.dwUsage = ResourceUsage.RESOURCEUSAGE_CONNECTABLE;
                netresource_0.lpLocalName = (string)null;
                netresource_0.lpRemoteName = ipcname;
                netresource_0.pProvider = (string)null;

             
                result = WNetAddConnection3((IntPtr)0, ref netresource_0, ref password, ref username, 0);
            }
            catch (Exception ex)
            {

                CloseConnection(ipcname, ref num);
                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);

            }

        }

        public static String GetDomainName (String ServerName)
        {

            IntPtr domainPtr= new IntPtr ();
            int result=0;

            String DomaiName = String.Empty;
            try
            {

                result = NetWkstaGetInfo(ServerName, 100, out domainPtr);

                if ( result ==ErrorConstants.ERROR_ACCESS_DENIED)
                {
                    EstablishConnectionWithPrompt(ServerName, String.Empty, String.Empty, ref result);

                        if(result==ErrorConstants.NERR_Success )
                      {
                            result = NetWkstaGetInfo(ServerName, 100, out  domainPtr);

                      }
                }

                if (result == ErrorConstants.NERR_Success)
                {
                    WKSTA_INFO_100 wksta_info = (WKSTA_INFO_100)Marshal.PtrToStructure(domainPtr, typeof(WKSTA_INFO_100));

                        if (!string.IsNullOrEmpty(wksta_info.lan_group))
                            DomaiName= wksta_info.lan_group;
                    
                }



                NetAPICommon.NetApiBufferFree(domainPtr);

            }
            catch (Exception ex)
            {
                
                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return DomaiName;
        }

    }
}
