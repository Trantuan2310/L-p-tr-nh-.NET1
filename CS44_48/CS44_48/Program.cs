namespace CS44_48
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("\n1. Chay CS44.cs Uri, Dns, Ping");
                Console.WriteLine("2. Chay CS45.cs HttpClient");
                Console.WriteLine("3. Chay CS46.cs HttpMessageHandler");
                Console.WriteLine("4. Chay CS47.cs HttpListener");
                Console.WriteLine("5. Chay CS48.cs Tcp TcpListenerr/TcpClient");
                Console.WriteLine("6. Chay Client48.cs");
                Console.WriteLine("7. Thoat\n");

                string choice;

                while (true)
                {
                    Console.Write("Chon File de chay (1-7): ");
                    choice = Console.ReadLine();

                    if (choice == "1" || choice == "2" || choice == "3"
                     || choice == "4" || choice == "5" || choice == "6"
                     || choice == "7")
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
                        CS44.Program44.Run();
                        break;
                    case "2":
                        CS45.Program45.Run();
                        break;
                    case "3":
                        CS46.Program46.Run();
                        break;
                    case "4":
                        CS47.Program47.Run();
                        break;
                    case "5":
                        CS48.Program48.Run();
                        break;
                    case "6":
                        Client48.Client48.Run();
                        break;
                    case "7":
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
