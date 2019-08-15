using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNC_Server_Setup_Wizard
{
    public class VNC_Feature
    {
        public FeatureName Name { get; set; }
        public bool Enabled { get; set; }

        public enum FeatureName { EnableRemotePrinting, ShareFiles, EnableChat, AudioEnable, CutText, AcceptPointerEvents, AcceptKeyEvents }

        public VNC_Feature(FeatureName name, bool enabled)
        {
            Name = name;
            Enabled = enabled;
        }
    }
}
