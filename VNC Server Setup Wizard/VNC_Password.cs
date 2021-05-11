using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VNC_Server_Setup_Wizard
{
    public static class VNC_Password
    {
        public static bool SetEncryptedPassword(string pwd)
        {
            Process pwdps = new Process();
            pwdps.StartInfo.FileName = "cmd.exe";
            pwd = pwd.Replace("^", "^^^^").Replace("&", "^^^&").Replace("<", "^^^<").Replace(">", "^^^>").Replace("|", "^^^|").Replace("\"", "^^^\"");
            pwdps.StartInfo.Arguments = "/c chcp 65001 >nul & echo " + pwd + " | \"C:\\Program Files\\RealVNC\\VNC Server\\vncpasswd.exe\" -service";
            pwdps.StartInfo.UseShellExecute = false;
            pwdps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pwdps.StartInfo.CreateNoWindow = true;
            pwdps.Start();
            pwdps.WaitForExit();
            if (pwdps.ExitCode != 0) { return false; }
            else { return true; }
        }
    }
}
