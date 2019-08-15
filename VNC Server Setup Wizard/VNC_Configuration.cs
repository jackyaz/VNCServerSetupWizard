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
        public enum Authentication { VNCAuth, SystemAuth, SingleSignOn_SystemAuth }

        public readonly string credentialfile = "C:\\ProgramData\\RealVNC-Service\\vncserver.d\\CloudCredentials.bed";

        public PlanType Plan { get; set; }
        public Authentication Auth { get; set; }
        public List<VNC_User> VNCUsers { get; set; }
        public List<VNC_Feature> VNCFeatures { get; set; }

        public VNC_Configuration()
        {

        }
    }
}
