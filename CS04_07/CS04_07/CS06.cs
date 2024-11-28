namespace CS06
{
    class Program06
    {
        public static void Run()
        {           
            // Vòng lặp for
            Console.WriteLine("Vong lap for");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"So i = {i}");
            }

            // Vòng lặp while
            Console.WriteLine("Vong lap while");
            int j = 10;
            while (j <= 15)
            {
                Console.WriteLine("So j = " + j++);
            }

            // Vòng lặp do ... while
            Console.WriteLine("Vong lap do ... while");
            int a = 2;
            do
            {
                Console.WriteLine($"So a = " + a);
                a += 2;
            }
            while (a <= 10);

            // Break và continue
            Console.WriteLine("Break va Continue");
            for (int b = 1; b <= 10; b++)
            {
                if (b % 3 != 0)
                    continue;
                Console.WriteLine("So b = " + b);
            }

            int c = 0;
            while (true)
            {
                Console.Write(" " + ++c);
                if (c == 5)
                    break;
            }
        }
    }
}