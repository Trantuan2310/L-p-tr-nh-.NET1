namespace CS55_57
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Bo comment de chay cac phan khac nhau trong file");
                Console.ResetColor();
                Console.WriteLine("\n1. Chay CS55.cs Query");
                Console.WriteLine("2. Chay CS56.cs Scaffold");
                Console.WriteLine("3. Chay CS57.cs Migration");
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
                        await CS55.Program55.Run();
                        break;
                    case "2":
                        await CS56.Program56.Run();
                        break;
                    case "3":
                        await CS57.Program57.Run();
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
