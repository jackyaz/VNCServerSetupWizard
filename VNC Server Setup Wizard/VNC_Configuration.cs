using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNC_Server_Setup_Wizard
{
    public class VNC_Configuration
    {
        public enum PlanType { Home, Professional, Enterprise }
        public enum PermissionType { Admin, Standard, ViewOnly, None }
        public enum AuthenticationType { VncAuth, SystemAuth, SingleSignOn_SystemAuth }
        public enum EncryptionType { AES128, AES256 }

        public readonly string credentialfile = "C:\\ProgramData\\RealVNC-Service\\vncserver.d\\CloudCredentials.bed";

        public PlanType Plan { get; set; }
        public AuthenticationType Authentication { get; set; }
        public EncryptionType Encryption { get; set; }
        public List<VNC_User> VNCUsers { get; set; }
        public List<VNC_Feature> VNCFeatures { get; set; }

        public string EncryptedPassword { get; set; }

        public VNC_Configuration()
        {
            VNCUsers = new List<VNC_User>();
            VNCFeatures = new List<VNC_Feature>();
            EncryptedPassword = "";
        }

        public bool SaveConfiguration()
        {
            bool success = true;

            // Authentication
            try
            {
                RegistryManagement.SetRegistryValue(RegHives.HKLM, "Authentication", this.Authentication.ToString().Replace("_", ","));
                if(this.Authentication == AuthenticationType.VncAuth)
                {
                    RegistryManagement.SetRegistryValue(RegHives.HKLM, "Password", this.EncryptedPassword);
                }
            }
            catch { success = false; }

            // Encryption
            string encryption = "";
            if (this.Encryption == EncryptionType.AES128) { encryption = "AlwaysOn"; } else if (this.Encryption == EncryptionType.AES256) { encryption = "AlwaysMaximum"; }
            try { RegistryManagement.SetRegistryValue(RegHives.HKLM, "Encryption", encryption); }
            catch { success = false; }

            // Features
            foreach (VNC_Feature feature in VNCFeatures)
            {
                string enabled = "0";
                if (feature.Enabled) { enabled = "1"; } else { enabled = "0"; }

                if (feature.Name == VNC_Feature.FeatureName.CutText)
                {
                    try
                    {
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "AcceptCutText", enabled);
                        RegistryManagement.SetRegistryValue(RegHives.HKLM, "SendCutText", enabled);
                    }
                    catch { success = false; }
                }
                else
                {
                    try { RegistryManagement.SetRegistryValue(RegHives.HKLM, feature.Name.ToString(), enabled); ; }
                    catch { success = false; }
                }
            }

            return success;
        }
    }
}
