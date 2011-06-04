using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.Management;

namespace neprostopleer.Cores
{
    class CoreSettings
    {
        private string[] protectedProperties = new string[] { "lastfm_password", "pp_password" };

        private byte[] additionalEntropy;

        public CoreSettings()
        {
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Select * from Win32_OperatingSystem");
            ManagementObjectCollection objMOC;

            objMOC = objMOS.Get();
            string serial = null;
            string user = null;
            foreach (ManagementObject objMO in objMOC)
            {
                serial = objMO["SerialNumber"].ToString();
            }


            objMOS = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            objMOC = objMOS.Get();

            foreach (ManagementObject objMO in objMOC)
            {
                user = objMO["UserName"].ToString();
            }
            byte[] serialbytes = System.Text.Encoding.UTF8.GetBytes(serial);
            byte[] serialuser = System.Text.Encoding.UTF8.GetBytes(user);
            additionalEntropy = serialbytes.Concat<byte>(serialuser).ToArray();
        }

        public object this[string key]
        {
            get
            {
                string val = ConfigurationSettings.AppSettings[key];
                if (protectedProperties.Contains<string>(key))
                {
                    return System.Text.UTF8Encoding.UTF8.GetString(ProtectedData.Unprotect(System.Convert.FromBase64String(val), additionalEntropy, DataProtectionScope.CurrentUser));
                }
                else
                {
                    return val;
                }
            }
            set
            {
                if (protectedProperties.Contains<string>(key))
                {
                    string val = System.Convert.ToBase64String(ProtectedData.Protect(System.Text.Encoding.UTF8.GetBytes((string)value), additionalEntropy, DataProtectionScope.CurrentUser));
                    ConfigurationSettings.AppSettings[key] = (string)val;
                    
                }
                else
                {
                    ConfigurationSettings.AppSettings[key] = (string)value;
                }
            }
        }
    }
}
