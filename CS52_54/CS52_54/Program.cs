namespace CS52_54
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
                Console.WriteLine("\n1. Chay CS52.cs Tong quan");
                Console.WriteLine("2. Chay CS53.cs Tao Model");
                Console.WriteLine("3. Chay CS54.cs Fluent API");
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
                        CS52.Program52.Run();
                        break;
                    case "2":
                        CS53.Program53.Run();
                        break;
                    case "3":
                        CS54.Program54.Run();
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
