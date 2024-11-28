namespace CS15_21
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS27.cs Ngoai le Exception");
                Console.WriteLine("2. Chay CS28.cs  IDisposable & Using");
                Console.WriteLine("3. Chay CS29.cs File");
                Console.WriteLine("4. Chay CS30.cs FileStream");
                Console.WriteLine("5. Chay CS31.cs Collection & List");
                Console.WriteLine("6. Chay CS32.cs SortedList");
                Console.WriteLine("7. Chay CS33.cs Queue & Stack ");
                Console.WriteLine("8. Chay CS34.cs LinkedList ");
                Console.WriteLine("9. Thoat\n");

                string choice;

                while (true)
                {
                    Console.Write("Chon File de chay (1-9): ");
                    choice = Console.ReadLine();

                    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" ||
                        choice == "5" || choice == "6" || choice == "7" || choice == "8" ||
                        choice == "9")
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
                        CS27.Program27.Run();
                        break;
                    case "2":
                        CS28.Program28.Run();
                        break;
                    case "3":
                        CS29.Program29.Run();
                        break;
                    case "4":
                        CS30.Program30.Run();
                        break;
                    case "5":
                        CS31.Program31.Run();
                        break;
                    case "6":
                        CS32.Program32.Run();
                        break;
                    case "7":
                        CS33.Program33.Run();
                        break;
                    case "8":
                        CS34.Program34.Run();
                        break;
                    case "9":
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
