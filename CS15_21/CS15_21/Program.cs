namespace CS15_21
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS15.cs Tinh ke thua");
                Console.WriteLine("2. Chay CS16.cs Namespace");
                Console.WriteLine("3. Chay CS17.cs Partial");
                Console.WriteLine("4. Chay CS18.cs Generic");
                Console.WriteLine("5. Chay CS19.cs Kieu vo danh");
                Console.WriteLine("6. Chay CS20.cs Null & Nullable");
                Console.WriteLine("7. Chay CS21.cs Tinh da hinh");
                Console.WriteLine("8. Thoat\n");

                string choice;

                while (true) 
                {
                    Console.Write("Chon File de chay (1-8): ");
                    choice = Console.ReadLine();

                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" ||
                        choice == "5" || choice == "6" || choice == "7" || choice == "8")
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
                        CS15.Program15.Run();
                        break;
                    case "2":
                        CS16.Program16.Run();
                        break;
                    case "3":
                        CS17.Program17.Run();
                        break;
                    case "4":
                        CS18.Program18.Run();
                        break;
                    case "5":
                        CS19.Program19.Run();
                        break;
                    case "6":
                        CS20.Program20.Run();
                        break;
                    case "7":
                        CS21.Program21.Run();
                        break;
                    case "8":
                        continueRunning = false;
                        Console.WriteLine("Thoat chuong trinh.");
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
