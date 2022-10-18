using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DriverEasyActivator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Driver Easy Activator | github.com/YungSamzy";
            if (File.Exists($"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Easeware\\DriverEasy\\license.dat"))
            {
                MessageBox.Show("Error! Couldn't activate because you already have a license key installed!", "Driver Easy Activator", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error! Run this program as administrator!", "Driver Easy Activator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!", "Driver Easy Activator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.WriteAllText($"error{DateTime.Now.ToString()}.log", ex.ToString());
                Console.WriteLine("Error log created!");
                Console.WriteLine("Please open an issue on the github!");
                Console.ReadKey();
                return;
            }
            Process[] DriverEasy = Process.GetProcessesByName("DriverEasy");
            foreach (Process process in DriverEasy)
            {
                process.Kill();
            }
            MessageBox.Show("Success!", "Driver Easy Activator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
