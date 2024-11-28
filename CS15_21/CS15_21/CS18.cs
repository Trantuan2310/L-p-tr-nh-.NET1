namespace CS18
{
    class Program18
    {
        public static void Run()
        {
            static void Swap<T>(ref T a, ref T b) // Sử dụng Generic
            {
                T c = a;
                a = b;
                b = c;
            }

            int a = 1;
            int b = 2;
            Swap<int>(ref a, ref b);
            System.Console.WriteLine($"a = {a}; b = {b}");

            string a1 = "A";
            string b1 = "B";
            Swap<string>(ref a1, ref b1);
            System.Console.WriteLine($"a1 = {a1}; b1 = {b1}");

            var myClass = new MyClass<double>(123.123);
            myClass.TestMethod(123);
        }
    }
    class MyClass<T> // Lop Generic
    {
        public T bien;
        public MyClass(T value)
        {
            bien = value;
        }
        public T TestMethod(T pr)
        {
            Console.WriteLine(pr);
            return bien;
        }
        public T thuoctinh { get; set; }
    }
}
