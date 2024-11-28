namespace CS08_14
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS08.cs ");
                Console.WriteLine("2. Chay CS09.cs");
                Console.WriteLine("3. Chay CS10.cs");
                Console.WriteLine("4. Chay CS11.cs");
                Console.WriteLine("5. Chay CS12.cs");
                Console.WriteLine("6. Chay CS13.cs");
                Console.WriteLine("7. Chay CS14.cs");
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
                        CS08.Program08.Run();
                        break;
                    case "2":
                        CS09.Program09.Run();
                        break;
                    case "3":
                        CS10.Program10.Run();
                        break;
                    case "4":
                        CS11.Program11.Run();
                        break;
                    case "5":
                        CS12.Program12.Run();
                        break;
                    case "6":
                        CS13.Program13.Run();
                        break;
                    case "7":
                        CS14.Program14.Run();
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
