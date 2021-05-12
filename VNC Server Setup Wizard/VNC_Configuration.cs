using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace VNC_Server_Setup_Wizard
{
    public class VNC_Configuration
    {
        /// <summary>
        /// Variables and enums for class
        /// </summary>
        private readonly string credentialfile = @"C:\ProgramData\RealVNC-Service\vncserver.d\CloudCredentials.bed";
        public enum PlanType { None, Home, Professional, Enterprise }
        //public enum PermissionType { Admin, Standard, ViewOnly, None }
        public enum AuthenticationType { VncAuth, SystemAuth, SingleSignOn, Certificate, RADIUS }
        public enum EncryptionType { AlwaysOn, AlwaysMaximum }
        public enum PermissionsType { CurrentUser, Adminstrators, Users, Custom }

        /// <summary>
        /// Properties for class
        /// </summary>
        public PlanType Plan { get; private set; }
        public AuthenticationType Authentication { get; set; }
        public EncryptionType Encryption { get; set; }
        public PermissionsType Permissions { get; set; }
        public bool AttendedAccess { get; set; }
        public string PermissionsString { get; set; }
        public bool CloudRfb { get; set; }
        public bool CloudRelay { get; set; }
        public bool DirectRfb { get; set; }
        public string CloudName { get; private set; }
        public string CloudTeam { get; private set; }
        public string RfbIPAddress { get; private set; }
        public string RfbHostAddress { get; private set; }
        public int RfbPort { get; private set; }

        public VNC_Configuration()
        {
            SetPlanType();
            SetCloudName();
            SetCloudTeam();
            SetRfbHostAddress();
            SetRfbIPAddress();
            SetRfbPort();
            LoadConfigurationFromRegistry();
        }

        internal string StripUnprintable(string input)
        {
            return Regex.Replace(new string(input.Where(c => !char.IsControl(c)).ToArray()), @"[^\u0000-\u007F]", string.Empty);
        }

        private void SetPlanType()
        {
            string plantype;
            if (File.Exists(credentialfile))
            {
                string cloudcreds = File.ReadAllText(credentialfile);
                plantype = StripUnprintable(cloudcreds.Substring(cloudcreds.LastIndexOf("cloud/plan") + 10, cloudcreds.IndexOf("cloud/principal") - (cloudcreds.LastIndexOf("cloud/plan") + 10)));
            }
            else if (RegistryManagement.GetRegistryValue(RegHives.HKLM_License, "vncserver_license").Length > 1)
            {
                plantype = "Enterprise";
            }
            else
            {
                plantype = "None";
            }

            Enum.TryParse(plantype, out PlanType enumplantype);
            this.Plan = enumplantype;
        }

        #region Connection Information

        private void SetCloudName()
        {
            if (File.Exists(credentialfile))
            {
                string cloudcreds = File.ReadAllText(credentialfile);
                CloudName = StripUnprintable(cloudcreds.Substring(cloudcreds.LastIndexOf("cloud/my-name") + 13, cloudcreds.IndexOf("cloud/my-secret") - (cloudcreds.LastIndexOf("cloud/my-name") + 13)));
            }
            else
            {
                CloudName = "N/A";
            }
        }

        private void SetCloudTeam()
        {
            if (File.Exists(credentialfile))
            {
                string cloudcreds = File.ReadAllText(credentialfile);
                CloudTeam = StripUnprintable(cloudcreds.Substring(cloudcreds.LastIndexOf("cloud/team-name") + 15, cloudcreds.IndexOf("cloud/plan-trial") - (cloudcreds.LastIndexOf("cloud/team-name") + 15)));
            }
            else
            {
                CloudTeam = "N/A";
            }
        }

        private void SetRfbIPAddress()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 53);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    RfbIPAddress = endPoint.Address.ToString();
                }
            }
            catch { RfbIPAddress = "Could not determine IP address"; }
        }

        private void SetRfbHostAddress()
        {
            try
            {
                RfbHostAddress = Dns.GetHostName();
            }
            catch { RfbHostAddress = "Could not determine computer name"; }
        }

        private void SetRfbPort()
        {
            try
            {
                RfbPort = Convert.ToInt32(RegistryManagement.GetRegistryValue(RegHives.HKLM, "RfbPort"));
            }
            catch { RfbPort = 5900; }
        }

        #endregion
        public void LoadConfigurationFromRegistry()
        {
            // Authentication
            try
            {
                switch (RegistryManagement.GetRegistryValue(RegHives.HKLM, "Authentication"))
                {
                    case "VncAuth":
                        Authentication = AuthenticationType.VncAuth;
                        break;
                    case "SingleSignOn,SystemAuth":
                        Authentication = AuthenticationType.SingleSignOn;
                        break;
                    case "Certificate":
                        Authentication = AuthenticationType.Certificate;
                        break;
                    case "SystemAuth+RADIUS":
                        Authentication = AuthenticationType.RADIUS;
                        break;
                    default:
                        Authentication = AuthenticationType.SystemAuth;
                        break;
                }
            }
            catch { Authentication = AuthenticationType.SystemAuth; }

            // Encryption
            try
            {
                switch (RegistryManagement.GetRegistryValue(RegHives.HKLM, "Encryption"))
                {
                    case "AlwaysMaximum":
                        Encryption = EncryptionType.AlwaysMaximum;
                        break;
                    default:
                        Encryption = EncryptionType.AlwaysOn;
                        break;
                }
            }
            catch { Encryption = EncryptionType.AlwaysOn; }

            // Access Control
            try
            {
                PermissionsString = RegistryManagement.GetRegistryValue(RegHives.HKLM, "Permissions");

                if (PermissionsString == "%S-1-5-32-544:d" || PermissionsString == "%S-1-5-32-544:f" || PermissionsString == "")
                {
                    Permissions = PermissionsType.Adminstrators;
                }
                else if (PermissionsString == "%S-1-5-32-544:d,%S-1-5-32-545:d" || PermissionsString == "%S-1-5-32-544:d,%S-1-5-32-545:d")
                {
                    Permissions = PermissionsType.Users;
                }
                else if (PermissionsString == System.Security.Principal.WindowsIdentity.GetCurrent().User.ToString() + ":d"
                    || PermissionsString == System.Security.Principal.WindowsIdentity.GetCurrent().User.ToString() + ":f")
                {
                    Permissions = PermissionsType.CurrentUser;
                }
                else
                {
                    Permissions = PermissionsType.Custom;
                }
            }
            catch { Permissions = PermissionsType.Adminstrators; }

            // Attended Access
            try
            {
                AttendedAccess = Convert.ToBoolean(Convert.ToInt32(RegistryManagement.GetRegistryValue(RegHives.HKLM, "QueryConnect")));
            }
            catch { AttendedAccess = false; }

            // Connection types
            try
            {
                CloudRfb = Convert.ToBoolean(Convert.ToInt32(RegistryManagement.GetRegistryValue(RegHives.HKLM, "AllowCloudRfb")));
            }
            catch { CloudRfb = true; }

            try
            {
                CloudRelay = Convert.ToBoolean(Convert.ToInt32(RegistryManagement.GetRegistryValue(RegHives.HKLM, "AllowCloudRelay")));
            }
            catch { CloudRelay = true; }

            try
            {
                DirectRfb = Convert.ToBoolean(Convert.ToInt32(RegistryManagement.GetRegistryValue(RegHives.HKLM, "AllowIpListenRfb")));
            }
            catch { DirectRfb = false; }
        }

        public bool SaveConfigurationToRegistry()
        {
            // Authentication
            try
            {
                switch (Authentication)
                {
                    case AuthenticationType.SingleSignOn:
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "Authentication", "SingleSignOn,SystemAuth");
                        break;
                    case AuthenticationType.RADIUS:
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "Authentication", "SystemAuth+RADIUS");
                        break;
                    default:
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "Authentication", Authentication.ToString());
                        break;
                }
            }
            catch { return false; }

            // Encryption
            try
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "Encryption", Encryption.ToString());
            }
            catch { return false; }

            // Access Control
            try
            {
                switch (Permissions)
                {
                    case PermissionsType.Adminstrators:
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "Permissions", "%S-1-5-32-544:d");
                        break;
                    case PermissionsType.Users:
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "Permissions", "%S-1-5-32-544:d,%S-1-5-32-545:d");
                        break;
                    case PermissionsType.CurrentUser:
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "Permissions", System.Security.Principal.WindowsIdentity.GetCurrent().User.ToString() + ":d");
                        break;
                }
            }
            catch { return false; }

            // Attended Access
            try
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "QueryConnect", Convert.ToInt32(AttendedAccess).ToString());
                // as we're keeping it simple, we'll also set QueryOnlyIfLoggedOn
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "QueryOnlyIfLoggedOn", Convert.ToInt32(AttendedAccess).ToString());
            }
            catch { return false; }

            // Connections
            try
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "AllowCloudRfb", Convert.ToInt32(CloudRfb).ToString());
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "AllowCloudRelay", Convert.ToInt32(CloudRelay).ToString());
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "AllowIpListenRfb", Convert.ToInt32(DirectRfb).ToString());
            }
            catch { return false; }

            return true;
        }
    }
}
