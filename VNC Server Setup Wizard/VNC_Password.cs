using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VNC_Server_Setup_Wizard
{
    public class VNC_Password
    {
        public static string GetEncryptedPassword(string pwd)
        {
            Process pwdps = new Process();
            pwdps.StartInfo.FileName = "cmd.exe";
            pwd = pwd.Replace("^","^^^^").Replace("&","^^^&").Replace("<","^^^<").Replace(">","^^^>").Replace("|","^^^|").Replace("\"", "^^^\"");
            pwdps.StartInfo.Arguments = "/c chcp 65001 >nul & echo " + pwd + " | \"C:\\Program Files\\RealVNC\\VNC Server\\vncpasswd.exe\" -print";
            pwdps.StartInfo.UseShellExecute = false;
            pwdps.StartInfo.RedirectStandardOutput = true;
            pwdps.StartInfo.RedirectStandardError = true;
            pwdps.Start();
            string output = pwdps.StandardOutput.ReadToEnd();
            string error = pwdps.StandardError.ReadToEnd();
            string encpwd = "";
            if (output.Length > 0)
            {
                encpwd = output.Substring(9);
            }
            if (error.Length > 0)
            {
                encpwd = "error";
            }
            pwdps.WaitForExit();
            return encpwd;
        }
    }
}
