using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace AMT.Common.Win32Api
{
   public  class NetAPICommon
    {
       public enum SID_NAME_USE
       {
           SidTypeUser = 1,
           SidTypeGroup,
           SidTypeDomain,
           SidTypeAlias,
           SidTypeWellKnownGroup,
           SidTypeDeletedAccount,
           SidTypeInvalid,
           SidTypeUnknown,
           SidTypeComputer
       }
      

       [StructLayout(LayoutKind.Sequential)]
       public struct ACL_SIZE_INFORMATION
       {
           public uint AceCount;
           public uint AclBytesInUse;
           public uint AclBytesFree;
       }

       [StructLayout(LayoutKind.Sequential)]
       public struct ACE_HEADER
       {
           public byte AceType;
           public byte AceFlags;
           public short AceSize;
       }

       [StructLayout(LayoutKind.Sequential)]
       public struct ACCESS_ALLOWED_ACE
       {
           public ACE_HEADER Header;
           public int Mask;
           public int SidStart;
       }

       public enum ACL_INFORMATION_CLASS
       {
           AclRevisionInformation = 1,
           AclSizeInformation
       }




        [DllImport("Netapi32.dll", SetLastError = true)]
        public static extern int NetApiBufferFree (IntPtr Buffer);



        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetSecurityDescriptorDacl (
            IntPtr pSecurityDescriptor,
            [MarshalAs(UnmanagedType.Bool)] out bool bDaclPresent,
            ref IntPtr pDacl,
            [MarshalAs(UnmanagedType.Bool)] out bool bDaclDefaulted
            );


        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetAclInformation (
           IntPtr pAcl,
           ref ACL_SIZE_INFORMATION pAclInformation,
            uint nAclInformationLength,
            ACL_INFORMATION_CLASS dwAclInformationClass
         );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetAce (
             IntPtr aclPtr,
             int aceIndex,
             out IntPtr acePtr
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetLengthSid (
            IntPtr pSID
         );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConvertSidToStringSid (
            [MarshalAs(UnmanagedType.LPArray)] byte[] pSID,
            out IntPtr ptrSid
         );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool LookupAccountSid (
         string lpSystemName,
         [MarshalAs(UnmanagedType.LPArray)] byte[] Sid,
          System.Text.StringBuilder lpName,
          ref uint cchName,
          System.Text.StringBuilder ReferencedDomainName,
          ref uint cchReferencedDomainName,
          out SID_NAME_USE peUse);

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool PathIsUNC(
            [MarshalAsAttribute(UnmanagedType.LPWStr), In] string pszPath); 

    }
}
