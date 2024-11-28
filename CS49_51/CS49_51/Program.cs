namespace CS49_51
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Bo comment de chay cac phan khac nhau trong file");
                Console.ResetColor();
                Console.WriteLine("\n1. Chay CS49.cs SqlConnection");
                Console.WriteLine("2. Chay CS50.cs SqlCommand");
                Console.WriteLine("3. Chay CS51.cs DataAdapter - Co 1 file WPF CS51");
                Console.WriteLine("4. Thoat\n");

                string choice;

                while (true)
                {
                    Console.Write("Chon File de chay (1-4): ");
                    choice = Console.ReadLine();

                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                    }
                }

                switch (choice)
                {
                    case "1":
                        CS49.Program49.Run();
                        break;
                    case "2":
                        CS50.Program50.Run();
                        break;
                    case "3":
                        CS51.Program51.Run();
                        break;
                    case "4":
                        continueRunning = false;
                        Console.WriteLine("Thoat chuong trinh");
                        break;
                }

                if (continueRunning)
                {
                    Console.Write("\nBan co muon chay file khac khong? (y/n): ");
                    string continueChoice = Console.ReadLine();
                    if (continueChoice.ToLower() != "y")
                    {
                        continueRunning = false;
                        Console.WriteLine("Thoat chuong trinh.");
                    }
                }
            }
        }
    }
}
