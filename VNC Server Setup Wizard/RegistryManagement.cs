using System;
using Microsoft.Win32;

namespace VNC_Server_Setup_Wizard
{
    public enum RegHives { HKLM_License, HKLM }

    /// <summary>
    /// A class to manage reading/writing to specific Registry keys
    /// </summary>
    public static class RegistryManagement
    {
        /// <summary>
        /// Returns the relevant Registry key for HKLM on 32bit and 64bit Windows OS
        /// </summary>
        /// <returns>The correct Regsitry key for the system architecture</returns>
        private static RegistryKey GetHKLM()
        {
            RegistryKey localMachineRegistry;

            if (Environment.Is64BitOperatingSystem) { localMachineRegistry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64); }
            else { localMachineRegistry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32); }

            return localMachineRegistry;
        }

        /// <summary>
        /// Retrieves the current value for a specified String value in the Registry Key for DisplaySwitch or VNC Server
        /// </summary>
        /// <param name="reg">Whether the key to be set belongs to Local Machine or Current User</param>
        /// <param name="valuename">The name of the String to retrieve</param>
        /// <returns>The value of the String</returns>
        public static string GetRegistryValue(RegHives reg, string valuename)
        {
            RegistryKey regkey;
            if (reg == RegHives.HKLM) { regkey = RegistryManagement.GetHKLM().OpenSubKey("SOFTWARE\\RealVNC\\vncserver", false); }
            else { regkey = RegistryManagement.GetHKLM().OpenSubKey("SOFTWARE\\RealVNC", false); }
            string value = "";
            try { value = regkey.GetValue(valuename).ToString(); regkey.Close(); }
            catch {  }
            return value;
        }

        /// <summary>
        /// Sets the value for a specified String value in the Registry Key for DisplaySwitch or VNC Server
        /// </summary>
        /// <param name="reg">Whether the key to be set belongs to Local Machine or Current User</param>
        /// <param name="valuename">The name of the String to set</param>
        /// <param name="value">The value to set</param>
        public static void SetRegistryValue(RegHives reg, string valuename, string value)
        {
            RegistryKey regkey;
            if (reg == RegHives.HKLM) { regkey = RegistryManagement.GetHKLM().CreateSubKey("SOFTWARE\\RealVNC\\vncserver", true); }
            else { regkey = RegistryManagement.GetHKLM().CreateSubKey("SOFTWARE\\RealVNC", true); }
            regkey.SetValue(valuename, value, RegistryValueKind.String);
            regkey.Close();
        }
    }
}
