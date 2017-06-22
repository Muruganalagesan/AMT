using AMT.Logger;
using AMT.ReportingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace AMT.Common.Win32Api
{
    public  class NetShareWrapper
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetSecurityDescriptorDacl (
            IntPtr pSecurityDescriptor,
            [MarshalAs(UnmanagedType.Bool)] out bool bDaclPresent,
            ref IntPtr pDacl,
            [MarshalAs(UnmanagedType.Bool)] out bool bDaclDefaulted
            );

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode)]
        private static extern int NetShareEnum (
             StringBuilder ServerName,
             int level,
             ref IntPtr bufPtr,
             uint prefmaxlen,
             ref int entriesread,
             ref int totalentries,
             ref int resume_handle
             );


        [DllImport("Netapi32.dll", SetLastError = true)]
        public static extern int NetShareGetInfo (
            [MarshalAs(UnmanagedType.LPWStr)] string serverName,
            [MarshalAs(UnmanagedType.LPWStr)] string netName,
            Int32 level,
            out IntPtr bufPtr);

        public enum SHARE_TYPE : uint
        {
            STYPE_DISKTREE = 0,
            STYPE_PRINTQ = 1,
            STYPE_DEVICE = 2,
            STYPE_IPC = 3,
            STYPE_SPECIAL = 0x80000000,
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHARE_INFO_503
        {
            public string shi503_netname;
            [MarshalAs(UnmanagedType.U4)]
            public SHARE_TYPE shi503_type;
            public string shi503_remark;
            [MarshalAs(UnmanagedType.U4)]
            public int shi503_permissions;    // used w/ share level security only
            [MarshalAs(UnmanagedType.U4)]
            public int shi503_max_uses;
            [MarshalAs(UnmanagedType.U4)]
            public int shi503_current_uses;
            public string shi503_path;
            public string shi503_passwd;    // used w/ share level security only
            public string shi503_servername;
            [MarshalAs(UnmanagedType.U4)]
            public int shi503_reserved;
            public IntPtr shi503_security_descriptor;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct SHARE_INFO_502
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string shi502_netname;
            public uint shi502_type;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string shi502_remark;
            public Int32 shi502_permissions;
            public Int32 shi502_max_uses;
            public Int32 shi502_current_uses;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string shi502_path;
            public IntPtr shi502_passwd;
            public Int32 shi502_reserved;
            public IntPtr shi502_security_descriptor;
        }


        public List<ShareInfo> EnumNetSharesWithPermission (string ServerName)
        {
            List<ShareInfo> ShareInfos = new List<ShareInfo>();
            int entriesread = 0;
            int totalentries = 0;
            int resume_handle = 0;
            int nStructSize = Marshal.SizeOf(typeof(NetShareWrapper.SHARE_INFO_503));
            IntPtr bufPtr = IntPtr.Zero;
            StringBuilder server = new StringBuilder(ServerName);

            try
            {
                int ret = NetShareWrapper.NetShareEnum(server, 503, ref bufPtr, ErrorConstants.MAX_PREFERRED_LENGTH, ref entriesread, ref totalentries, ref resume_handle);

                if (ret == ErrorConstants.ERROR_ACCESS_DENIED)
                {


                    NetAPIConnection.EstablishConnectionWithPrompt(ServerName, String.Empty, String.Empty, ref ret);

                    if (ret == ErrorConstants.NERR_Success)
                        ret = NetShareWrapper.NetShareEnum(server, 503, ref bufPtr, ErrorConstants.MAX_PREFERRED_LENGTH, ref entriesread, ref totalentries, ref resume_handle);

                }

                if (ret == ErrorConstants.NERR_Success)
                {
                    IntPtr currentPtr = bufPtr;
                    for (int i = 0; i < entriesread; i++)
                    {

                        List<SharePermission> permissionItem = null;

                        NetShareWrapper.SHARE_INFO_503 shi1 = (NetShareWrapper.SHARE_INFO_503)Marshal.PtrToStructure(currentPtr, typeof(NetShareWrapper.SHARE_INFO_503));



                        if (shi1.shi503_security_descriptor != null && shi1.shi503_security_descriptor != IntPtr.Zero)
                        {
                            permissionItem = GetSharePermission(currentPtr);
                        }




                        ShareInfos.Add(new ShareInfo()
                        {
                            CurrentUses = shi1.shi503_current_uses,
                            Maxuses = shi1.shi503_max_uses,
                            Name = shi1.shi503_netname,
                            Path = shi1.shi503_path,
                            Permissions = shi1.shi503_permissions,
                            Remark = shi1.shi503_remark,
                            Reserved = shi1.shi503_reserved,
                            SecurityDescriptor = shi1.shi503_security_descriptor,
                            ServerName = ServerName,
                            Type = (int)shi1.shi503_type,

                            SharePermissions = permissionItem != null ? permissionItem : new List<SharePermission>()

                        });

                        currentPtr = (IntPtr)((ulong)currentPtr + (ulong)Marshal.SizeOf(shi1));

                    }
                    NetAPICommon.NetApiBufferFree(bufPtr);
                    
                }
                //else
                //{
                //    // ShareInfos.Add(new SHARE_INFO_1  NetShareWrapper.SHARE_INFO_503("ERROR=" + ret.ToString(), 10, string.Empty));
                  
                //}
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return ShareInfos;
        }

        private  List<SharePermission> GetSharePermission (IntPtr securityDescrPointer)
        {
            List<SharePermission> sharePermissionList = new List<SharePermission>();
            int Error = 0;

            try
            {
                NetShareWrapper.SHARE_INFO_503 shareInfo = (NetShareWrapper.SHARE_INFO_503)Marshal.PtrToStructure(securityDescrPointer, typeof(NetShareWrapper.SHARE_INFO_503));

                bool bDaclPresent;
                bool bDaclDefaulted;
                IntPtr pAcl = new IntPtr();// IntPtr.Zero;
                NetAPICommon.GetSecurityDescriptorDacl(shareInfo.shi503_security_descriptor, out bDaclPresent, ref pAcl, out bDaclDefaulted);
                if (bDaclPresent)
                {
                    NetAPICommon.ACL_SIZE_INFORMATION AclSize = new NetAPICommon.ACL_SIZE_INFORMATION();
                    NetAPICommon.GetAclInformation(pAcl, ref AclSize, (uint)Marshal.SizeOf(typeof(NetAPICommon.ACL_SIZE_INFORMATION)), NetAPICommon.ACL_INFORMATION_CLASS.AclSizeInformation);
                    for (int i = 0; i < AclSize.AceCount; i++)
                    {


                        SharePermission sharePermission = new SharePermission();
                        IntPtr pAce;
                        Error = NetAPICommon.GetAce(pAcl, i, out pAce);

                        NetAPICommon.ACCESS_ALLOWED_ACE ace = (NetAPICommon.ACCESS_ALLOWED_ACE)Marshal.PtrToStructure(pAce, typeof(NetAPICommon.ACCESS_ALLOWED_ACE));

                        IntPtr iter = (IntPtr)((long)pAce + (long)Marshal.OffsetOf(typeof(NetAPICommon.ACCESS_ALLOWED_ACE), "SidStart"));


                        byte[] bSID = null;
                        int size = (int)NetAPICommon.GetLengthSid(iter);
                        bSID = new byte[size];
                        Marshal.Copy(iter, bSID, 0, size);
                        IntPtr ptrSid;
                        NetAPICommon.ConvertSidToStringSid(bSID, out ptrSid);
                        string strSID = Marshal.PtrToStringAuto(ptrSid);

                        //Console.WriteLine("The details of ACE number {0} are ", i + 1);

                        StringBuilder UserName = new StringBuilder();
                        uint cchName = (uint)UserName.Capacity;
                        StringBuilder referencedDomainName = new StringBuilder();
                        uint cchReferencedDomainName = (uint)referencedDomainName.Capacity;
                        NetAPICommon.SID_NAME_USE sidUse;

                        NetAPICommon.LookupAccountSid(null, bSID, UserName, ref cchName, referencedDomainName, ref cchReferencedDomainName, out sidUse);

                        //Console.WriteLine("Trustee Name " + UserName);
                        //Console.WriteLine("Domain Name " + referencedDomainName);


                        sharePermission.UserName = UserName.ToString();
                        sharePermission.DomainName = referencedDomainName.ToString();


                        if ((ace.Mask & 0x1F01FF) == 0x1F01FF)
                        {

                            sharePermission.Permission = "Full Control";
                            //Console.WriteLine("Permission Full Control");
                        }
                        else if ((ace.Mask & 0x01BF) == 0x01BF)
                        {
                            sharePermission.Permission = "Read and Modify";
                            // Console.WriteLine("Permission READ and CHANGE");
                        }
                        else if ((ace.Mask & 0x1200A9) == 0x1200A9)
                        {
                            sharePermission.Permission = "Read";
                            //   Console.WriteLine("Permission READ only");
                        }

                        sharePermission.AcessType = ace.Header.AceType == 0 ? "Allow" : "Deny";
                        sharePermission.SID = strSID;

                        //   Console.WriteLine("SID {0} \nHeader AceType {1} \nAccess Mask {2} \nHeader AceFlag {3}", strSID, ace.Header.AceType.ToString(), ace.Mask.ToString(), ace.Header.AceFlags.ToString());
                        // Console.WriteLine("\n");

                        sharePermissionList.Add(sharePermission);
                    }


                    NetAPICommon.NetApiBufferFree(pAcl);
                }


            }




            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return sharePermissionList;




        }

        public List<BaseShareInfo> EnumNetShares (string ServerName)
        {
            List<BaseShareInfo> ShareInfos = new List<BaseShareInfo>();
            int entriesread = 0;
            int totalentries = 0;
            int resume_handle = 0;
            int nStructSize = Marshal.SizeOf(typeof(NetShareWrapper.SHARE_INFO_503));
            IntPtr bufPtr = IntPtr.Zero;
            StringBuilder server = new StringBuilder(ServerName);
            try
            {
                int ret = NetShareWrapper.NetShareEnum(server, 503, ref bufPtr, ErrorConstants.MAX_PREFERRED_LENGTH, ref entriesread, ref totalentries, ref resume_handle);

                if (ret == ErrorConstants.ERROR_ACCESS_DENIED)
                {
                    NetAPIConnection.EstablishConnectionWithPrompt(ServerName, String.Empty, String.Empty, ref ret);

                    if (ret == ErrorConstants.NERR_Success)
                        ret = NetShareWrapper.NetShareEnum(server, 503, ref bufPtr, ErrorConstants.MAX_PREFERRED_LENGTH, ref entriesread, ref totalentries, ref resume_handle);

                }

                if (ret == ErrorConstants.NERR_Success)
                {
                    IntPtr currentPtr = bufPtr;
                    for (int i = 0; i < entriesread; i++)
                    {
                        NetShareWrapper.SHARE_INFO_503 shi1 = (NetShareWrapper.SHARE_INFO_503)Marshal.PtrToStructure(currentPtr, typeof(NetShareWrapper.SHARE_INFO_503));

                        ShareInfos.Add(new BaseShareInfo()
                        {
                            ServerName = ServerName,
                            ShareName = shi1.shi503_netname,
                            SharePath = @"\\" + ServerName + @"\" + shi1.shi503_netname,
                            DomainName = NetAPIConnection.GetDomainName(ServerName)



                        });

                        currentPtr = (IntPtr)((ulong)currentPtr + (ulong)Marshal.SizeOf(shi1));

                    }
                    NetAPICommon.NetApiBufferFree(bufPtr);
                  
                }
               
               
            }
            catch (Exception ex)
            {

                AMTLogger.WriteToLog(ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
            }
            return ShareInfos;
        }

        
    }
}
