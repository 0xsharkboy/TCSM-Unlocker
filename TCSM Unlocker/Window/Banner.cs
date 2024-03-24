namespace TCSM_Unlocker
{
    internal class Banner
    {
        public void print_banner()
        {
            string banner = "  _______ _____  _____ __  __    _    _       _            _             \r\n" +
                            " |__   __/ ____|/ ____|  \\/  |  | |  | |     | |          | |            \r\n" +
                            "    | | | |    | (___ | \\  / |  | |  | |_ __ | | ___   ___| | _____ _ __ \r\n" +
                            "    | | | |     \\___ \\| |\\/| |  | |  | | '_ \\| |/ _ \\ / __| |/ / _ \\ '__|\r\n" +
                            "    | | | |____ ____) | |  | |  | |__| | | | | | (_) | (__|   <  __/ |   \r\n" +
                            "    |_|  \\_____|_____/|_|  |_|   \\____/|_| |_|_|\\___/ \\___|_|\\_\\___|_|   \r\n" +
                            "                                                                         \r\n" +
                            "                                                                         ";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(banner);
            Console.ResetColor();
        }
    }
}
