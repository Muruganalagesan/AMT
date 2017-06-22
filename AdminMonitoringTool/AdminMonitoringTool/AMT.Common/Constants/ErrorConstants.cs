using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMT.Common
{
    public  class ErrorConstants
    {
      //  const int MAX_PREFERRED_LENGTH = -1;
        // originally 0
        public const long ERROR_SUCCESS = 0L;// No errors encountered.

        public const long NERR_Success = 0L;

        public const long ERROR_ACCESS_DENIED = 5L;        // The user has insufficient privilege for this operation.
        public const long ERROR_NOT_ENOUGH_MEMORY = 8L;    // Not enough memory
        public const long ERROR_NETWORK_ACCESS_DENIED = 65L;   // Network access is denied.
        public const long ERROR_INVALID_PARAMETER = 87L;   // Invalid parameter specified.
        public const long ERROR_BAD_NETPATH = 53L; // The network path was not found.
        public const long ERROR_INVALID_NAME = 123L;   // Invalid name
        public const long ERROR_INVALID_LEVEL = 124L;  // Invalid level parameter.
        public const long ERROR_MORE_DATA = 234L;  // More data available, buffer too small.
        public const long NERR_BASE = 2100L;
        public const long NERR_NetNotStarted = 2102L;  // Device driver not installed.
        public const long NERR_RemoteOnly = 2106L; // This operation can be performed only on a server.
        public const long NERR_ServerNotStarted = 2114L;   // Server service not installed.
        public const long NERR_BufTooSmall = 2123L;    // Buffer too small for fixed-length data.
        public const long NERR_RemoteErr = 2127L;  // Error encountered while remotely.  executing function
        public const long NERR_WkstaNotStarted = 2138L;    // The Workstation service is not started.
        public const long NERR_BadTransactConfig = 2141L;  // The server is not configured for this transaction;  IPC$ is not shared.
        public const long NERR_NetNameNotFound = (NERR_BASE + 210);    // Sharename not found.

        public const long NERR_InvalidComputer = 2351L; // Invalid computername specified.

        public const uint MAX_PREFERRED_LENGTH = 0xFFFFFFFF;
      
    }
}
