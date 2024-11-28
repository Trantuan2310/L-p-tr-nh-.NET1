namespace CS22_26
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS22.cs Delegate");
                Console.WriteLine("2. Chay CS23.cs Lambda & Delegate");
                Console.WriteLine("3. Chay CS24.cs Event");
                Console.WriteLine("4. Chay CS25.cs Phuong thuc mo rong");
                Console.WriteLine("5. Chay CS26.cs Mot so chu de");
                Console.WriteLine("6. Thoat\n");

                string choice;

                while (true)
                {
                    Console.Write("Chon File de chay (1-6): ");
                    choice = Console.ReadLine();

                    if (choice == "1" || choice == "2" || choice == "3" 
                     || choice == "4" || choice == "5" || choice == "6")
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
                        CS22.Program22.Run();
                        break;
                    case "2":
                        CS23.Program23.Run();
                        break;
                    case "3":
                        CS24.Program24.Run();
                        break;
                    case "4":
                        CS25.Program25.Run();
                        break;
                    case "5":
                        CS26.Program26.Run();
                        break;
                    case "6":
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
