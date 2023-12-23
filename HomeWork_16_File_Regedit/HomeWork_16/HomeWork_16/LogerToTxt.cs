using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_16
{
    internal class LogerToTxt
    {
        public static async void LogToFile(string log)
        {
            var myFolder = "Loging";
            var location = Directory.GetCurrentDirectory();
            var allDir = Directory.GetDirectories(location);
            DirectoryInfo myDir = new DirectoryInfo($"{location}\\{myFolder}");
            if (!allDir.Contains($"{location}\\{myFolder}"))
            {
                myDir.Create();
            }
            var allFilesFullName = myDir.GetFiles().Select(x => x.FullName);
            if (!allFilesFullName.Contains($"{location}\\{myFolder}\\{DateTime.Now.ToString("yyyy-MM-dd")}.txt"))
            {
                using (StreamWriter writer = new StreamWriter($"{location}\\{myFolder}\\{DateTime.Now.ToString("yyyy-MM-dd")}.txt", false))
                {
                    await writer.WriteLineAsync($"Today first runing aplication {DateTime.Now}");
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter($"{location}\\{myFolder}\\{DateTime.Now.ToString("yyyy-MM-dd")}.txt", true))
                {
                    await writer.WriteLineAsync($"{log}, the program was raning {DateTime.Now}");
                }
            }
         
        }
    }
}
