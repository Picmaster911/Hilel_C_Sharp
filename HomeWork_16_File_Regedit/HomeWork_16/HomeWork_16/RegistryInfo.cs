using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_16
{
    internal class RegistryInfo
    {
        public static string InfoRegistry()
        {
            RegistryKey key = Registry.CurrentUser;
            var myKey = key.OpenSubKey("MyProgramSol");
            if (myKey == null)
            {
                CreateRegistryKey();
                var newKey = key.OpenSubKey("MyProgramSol");
                return $"Version = {newKey.GetValue("Version")}, Created {newKey.GetValue("FirstStartTime")}";
            }
            return $"Version = {myKey.GetValue("Version")}, Created {myKey.GetValue("FirstStartTime")}";
        }
        static void CreateRegistryKey()
        {
            RegistryKey key = Registry.CurrentUser;
            var newKey = key.CreateSubKey("MyProgramSol");
            if (newKey != null)
            {
                var dataNow = DateTime.Now;
                newKey.SetValue("Version", "1.0");
                newKey.SetValue("Status", "Active");
                newKey.SetValue("FirstStartTime", dataNow.ToString());
                key.Close();
            }
        }
    }
}
