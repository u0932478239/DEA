using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DriverEasyActivator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Driver Easy Activator | github.com/YungSamzy";
            Console.WriteLine("Activating...");
            if (File.Exists($"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Easeware\\DriverEasy\\license.dat"))
            {
                Console.WriteLine("Error! Couldn't activate because you already have a license key installed!");
                Console.ReadKey();
                return;
            }
            File.WriteAllBytes($"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Easeware\\DriverEasy\\license.dat", Resource1.license);
            try
            {
                File.AppendAllText("C:\\Windows\\System32\\Drivers\\etc\\Hosts", Environment.NewLine + "127.0.0.1 app.drivereasy.com");
                File.AppendAllText("C:\\Windows\\System32\\Drivers\\etc\\Hosts", Environment.NewLine + "127.0.0.1 cdn.drivereasy.com");
            }
            catch(System.UnauthorizedAccessException)
            {
                Console.WriteLine("Error! Run this program as administrator!");
                Console.WriteLine("We need administrator privileges to write to certian files on the computer!");
                Console.ReadKey();
                return;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Please open an issue on the github!");
                Console.ReadKey();
                return;
            }
            Process[] DriverEasy = Process.GetProcessesByName("DriverEasy");
            foreach (Process process in DriverEasy)
            {
                process.Kill();
            }
            Console.WriteLine("Success!");
        }
    }
}
