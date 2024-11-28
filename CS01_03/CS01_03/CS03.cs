namespace CS03
{
    class Program03
    {
        public static void Run()
        {
            string input;

            Console.Write("Nhap vao so a: ");
            input = Console.ReadLine();
            int a = int.Parse(input);

            Console.Write("Nhap vao so a: ");
            input = Console.ReadLine();
            int b = int.Parse(input);

            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            Console.WriteLine("a / b = {0}", a / b);
            Console.WriteLine("a % b = {0}", a % b);
            // x += 2 ==> x = x + 2 (tương tự với các toán tử còn lại)
        }
    }
}