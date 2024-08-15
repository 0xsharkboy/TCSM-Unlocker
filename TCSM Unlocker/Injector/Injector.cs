using System.Diagnostics;

namespace TCSM_Unlocker
{
    internal class Injector
    {
        public void Setup()
        {
            iniHandler ini_handler = new iniHandler();

            ini_handler.editIniVariable("GL\\DLLInjector.ini");
            Thread.Sleep(1000);
        }

        public void Kill_apps()
        {
            Kill_processes("DLLInjector");
            Kill_processes("Steam");
        }

        private void Kill_processes(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            Banner banner = new Banner();

            if (processes.Length > 0)
            {
                banner.print_banner();
                Console.WriteLine($"Killing {name}...");
                foreach (Process process in processes)
                {
                    process.Kill();
                }
                Thread.Sleep(1000);
            }
        }

        public void Inject_steam()
        {
            Banner banner = new Banner();
            updateDlcList updateDlcList = new updateDlcList();

            if (File.Exists(@"GL\DLLInjector.exe"))
            {
                Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + @"\GL");
                banner.print_banner();
                Console.WriteLine("Updating DLC list...");
                updateDlcList.updateDlcFromSteam();
                Console.WriteLine("Injecting DLCs...");
                Process.Start("DLLInjector.exe");
                Thread.Sleep(1000);
                Console.WriteLine("Done. Closing in 5 secs...");
                Thread.Sleep(5000);
            }
            else
            {
                banner.print_banner();
                Console.WriteLine("Injector not found. Closing in 5 secs...");
                Thread.Sleep(5000);
            }
        }
    }
}
