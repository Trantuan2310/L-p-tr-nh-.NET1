namespace CS04_07
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS04.cs");
                Console.WriteLine("2. Chay CS05.cs");
                Console.WriteLine("3. Chay CS06.cs");
                Console.WriteLine("4. Chay CS07.cs");
                Console.WriteLine("5. Thoat\n");

                string choice;

                while (true)
                {
                    Console.Write("Chon File de chay (1-4): ");
                    choice = Console.ReadLine();

                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
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
                        CS04.Program04.Run();
                        break;
                    case "2":
                        CS05.Program05.Run();
                        break;
                    case "3":
                        CS06.Program06.Run();
                        break;
                    case "4":
                        CS07.Program07.Run();
                        break;
                    case "5":
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
