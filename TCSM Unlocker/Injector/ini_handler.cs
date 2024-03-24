namespace TCSM_Unlocker
{
    internal class ini_handler
    {

        private string get_steam_path()
        {
            Banner banner = new Banner();
            string steamPath = @"C:\Program Files (x86)\Steam\steam.exe";
            string temp;

            while (true)
            {
                banner.print_banner();
                Console.Write($"Please enter steam.exe path (default is {steamPath}): ");
                temp = Console.ReadLine();
                if (!string.IsNullOrEmpty(temp))
                {
                    if (!(temp.EndsWith(@"\steam.exe") && File.Exists(temp)))
                    {
                        Console.WriteLine("Invalid Steam.exe path");
                        Thread.Sleep(1000);
                        continue;
                    }
                    return temp;
                }
                return steamPath;
            }
        }
        public void editIniVariable(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            FileAttributes attr = File.GetAttributes(filePath);

            attr = attr & ~FileAttributes.ReadOnly;
            File.SetAttributes(filePath, attr);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Exe"))
                {
                    lines[i] = "Exe = "+ get_steam_path();
                }
                if (lines[i].StartsWith("Dll"))
                {
                    lines[i] = "Dll = " + Directory.GetCurrentDirectory() + @"\GL\GreenLuma_2024_x86.dll";
                }
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
            attr = attr | FileAttributes.ReadOnly;
            File.SetAttributes(filePath, attr);
        }
    }
}