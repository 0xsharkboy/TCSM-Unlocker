namespace TCSM_Unlocker
{
    static class Program
    {
        static void Main(string[] args)
        {
            Choices choices = new Choices();
            Injector injector = new Injector();
            int choice;

            if (!Directory.Exists("GL"))
            {
                Console.WriteLine("Green Luma folder not found. Exiting...");
                Thread.Sleep(5000);
                return;
            }
            while ((choice = choices.get_choice()) != 3)
            {
                if (choice == 1)
                {
                    injector.Kill_apps();
                    injector.Inject_steam();
                    return;
                }
                else if (choice == 2)
                {
                    injector.Setup();
                }
            }
        }
    }
}