namespace CS35_39
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS35.cs Dictionary HashSet");
                Console.WriteLine("2. Chay CS36.cs ObservableCollection");
                Console.WriteLine("3. Chay CS37.cs LINQ");
                Console.WriteLine("4. Chay CS38.cs Multithreading async");
                Console.WriteLine("5. Chay CS39.cs Type");
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
                        CS35.Program35.Run();
                        break;
                    case "2":
                        CS36.Program36.Run();
                        break;
                    case "3":
                        CS37.Program37.Run();
                        break;
                    case "4":
                        CS38.Program38.Run();
                        break;
                    case "5":
                        CS39.Program39.Run();
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
