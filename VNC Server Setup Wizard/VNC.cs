using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNC_Server_Setup_Wizard
{
    public static class VNC_Definitions
    {
        public enum PlanType { Home, Professional, Enterprise }
        public enum PermissionType { Admin, Standard, ViewOnly, None }

        public enum Authentication {  VNCAuth, SystemAuth, SingleSignOn_SystemAuth }

        public static readonly string credentialfile = "C:\\ProgramData\\RealVNC-Service\\vncserver.d\\CloudCredentials.bed";

        private static PlanType plan;

        public static PlanType Plan
        {
            get { return plan; }
            set { plan = value; }
        }
    }
}
