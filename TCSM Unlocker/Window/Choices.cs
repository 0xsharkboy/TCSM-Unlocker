namespace TCSM_Unlocker
{
    internal class Choices
    {
        private bool is_valid_choice(int choice)
        {
            return (choice > 0 && choice < 4);
        }

        private void print_choices()
        {
            Console.WriteLine("1. Inject all DLCs");
            Console.WriteLine("2. Setup injector");
            Console.WriteLine("3. Exit");
        }

        public int get_choice()
        {
            Banner banner = new Banner();
            int choice;

            while (true)
            {
                banner.print_banner();
                print_choices();
                Console.Write("\nPlease select an option: ");
                if (Int32.TryParse(Console.ReadLine(), out choice) && is_valid_choice(choice))
                {
                    break;
                }
                Console.WriteLine("Please enter a valid option.");
                Thread.Sleep(500);
            }
            return choice;
        }
    }
}
