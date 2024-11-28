namespace CS01_03
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS01.cs");
                Console.WriteLine("2. Chay CS02.cs");
                Console.WriteLine("3. Chay CS03.cs");
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
                        CS01.Program01.Run();
                        break;
                    case "2":
                        CS02.Program02.Run();
                        break;
                    case "3":
                        CS03.Program03.Run();
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
