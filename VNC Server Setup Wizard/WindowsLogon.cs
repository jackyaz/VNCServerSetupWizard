using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace VNC_Server_Setup_Wizard
{
    internal static class WindowsLogon
    {
        private enum LogonType
        {
            /// <summary>
            /// This logon type is intended for users who will be interactively using the computer, such as a user being logged on  
            /// by a terminal server, remote shell, or similar process.
            /// This logon type has the additional expense of caching logon information for disconnected operations; 
            /// therefore, it is inappropriate for some client/server applications,
            /// such as a mail server.
            /// </summary>
            LOGON32_LOGON_INTERACTIVE = 2,

            /// <summary>
            /// This logon type is intended for high performance servers to authenticate plaintext passwords.
            /// The LogonUser function does not cache credentials for this logon type.
            /// </summary>
            LOGON32_LOGON_NETWORK = 3,

            /// <summary>
            /// This logon type is intended for batch servers, where processes may be executing on behalf of a user without 
            /// their direct intervention. This type is also for higher performance servers that process many plaintext
            /// authentication attempts at a time, such as mail or Web servers. 
            /// The LogonUser function does not cache credentials for this logon type.
            /// </summary>
            LOGON32_LOGON_BATCH = 4,

            /// <summary>
            /// Indicates a service-type logon. The account provided must have the service privilege enabled. 
            /// </summary>
            LOGON32_LOGON_SERVICE = 5,

            /// <summary>
            /// This logon type is for GINA DLLs that log on users who will be interactively using the computer. 
            /// This logon type can generate a unique audit record that shows when the workstation was unlocked. 
            /// </summary>
            LOGON32_LOGON_UNLOCK = 7,

            /// <summary>
            /// This logon type preserves the name and password in the authentication package, which allows the server to make 
            /// connections to other network servers while impersonating the client. A server can accept plaintext credentials 
            /// from a client, call LogonUser, verify that the user can access the system across the network, and still 
            /// communicate with other servers.
            /// NOTE: Windows NT:  This value is not supported. 
            /// </summary>
            LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

            /// <summary>
            /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
            /// The new logon session has the same local identifier but uses different credentials for other network connections. 
            /// NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
            /// NOTE: Windows NT:  This value is not supported. 
            /// </summary>
            LOGON32_LOGON_NEW_CREDENTIALS = 9,
        }

        private enum LogonProvider
        {
            /// <summary>
            /// Use the standard logon provider for the system. 
            /// The default security provider is negotiate, unless you pass NULL for the domain name and the user name 
            /// is not in UPN format. In this case, the default provider is NTLM. 
            /// NOTE: Windows 2000/NT:   The default security provider is NTLM.
            /// </summary>
            LOGON32_PROVIDER_DEFAULT = 0,
            LOGON32_PROVIDER_WINNT35 = 1,
            LOGON32_PROVIDER_WINNT40 = 2,
            LOGON32_PROVIDER_WINNT50 = 3
        }

        [DllImport("advapi32.dll", SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool LogonUser(
          [MarshalAs(UnmanagedType.LPStr)] string pszUserName,
          [MarshalAs(UnmanagedType.LPStr)] string pszDomain,
          [MarshalAs(UnmanagedType.LPStr)] string pszPassword,
          int dwLogonType,
          int dwLogonProvider,
          out IntPtr phToken);

        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr hObject);

        public static bool PasswordEnabled
        {
            get
            {
                IntPtr phToken;

                bool loggedIn = LogonUser(Environment.UserName, null, "", (int)LogonType.LOGON32_LOGON_INTERACTIVE, (int)LogonProvider.LOGON32_PROVIDER_DEFAULT, out phToken);

                int error = Marshal.GetLastWin32Error();

                if (phToken != IntPtr.Zero) { CloseHandle(phToken); }

                // 1327 = empty password
                if (loggedIn || error == 1327) { return false; } else { return true; }
            }
        }

        /// <summary>
        /// Determines whether the local machine is a member of a domain.
        /// </summary>
        /// <returns>A boolean value that indicated whether the local machine is a member of a domain.</returns>
        /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/aa394102%28v=vs.85%29.aspx</remarks>
        public static bool DomainMember
        {
            get
            {
                System.Management.ManagementObject ComputerSystem;
                using (ComputerSystem = new System.Management.ManagementObject(String.Format("Win32_ComputerSystem.Name='{0}'", Environment.MachineName)))
                {
                    ComputerSystem.Get();
                    object Result = ComputerSystem["PartOfDomain"];
                    return (Result != null && (bool)Result);
                }
            }
        }
    }
}
