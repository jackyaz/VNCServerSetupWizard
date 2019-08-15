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

        public static void EnableAllFeatures(VNC_Configuration config)
        {
            config.VNCFeatures = new List<VNC_Feature>();

            foreach (FeatureName feature in Enum.GetValues(typeof(FeatureName)))
            {
                config.VNCFeatures.Add(new VNC_Feature(feature, true));
            }
        }

        public static void EnableFreeFeatures(VNC_Configuration config)
        {
            config.VNCFeatures = new List<VNC_Feature>();

            foreach (FeatureName feature in Enum.GetValues(typeof(FeatureName)))
            {
                if (feature == FeatureName.CutText || feature == FeatureName.AcceptPointerEvents || feature == FeatureName.AcceptKeyEvents)
                {
                    config.VNCFeatures.Add(new VNC_Feature(feature, true));
                }
            }
        }
    }
}
