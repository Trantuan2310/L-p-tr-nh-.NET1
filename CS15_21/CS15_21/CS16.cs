namespace CS16 // Namespace
{
    class Program16
    {
        public static void Run()
        {
            Console.WriteLine("Hello Word");
            Name01.Class1.XinChao(); // Gọi đến namespace ở file khác (Class1.cs)
            Name02.Class1.XinChao();
        }
    }
    namespace Name02 // Namespace lồng
    {
        public class Class1
        {
            public static void XinChao()
            {
                Console.WriteLine("Namespace tu Name02");
            }
        }
    }
}

