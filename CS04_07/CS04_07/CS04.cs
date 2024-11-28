namespace CS04
{
    class Program04
    {
        public static void Run()
        {
            // Toán tử + - * / %
            int a = 6;
            int b = 3;
            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            Console.WriteLine("a / b = {0}", a / b);
            Console.WriteLine("a % b = {0}", a % b);

            // Thứ tự ưu tiên () xⁿ √ * / + -
            float kp = 6 / (2 + 3) * 2; // Thứ tự tính toán () -> / -> *
            Console.WriteLine("6 / (2 + 3) * 2 = {0}", kp);

            // Gán = += -= *= /= %=
            a += 6; // a = a + 6, các toán tử còn lại tương tự
            Console.WriteLine("a += 6 co ket qua là: {0}", a);

            // Toán tử tăng ++ và giảm --
            int x = 4;
            int c = 2 * x++; // ++ ở sau x thì phép toán thực hiện trước rồi tăng x
            Console.WriteLine("Ket qua cua bieu thuc c = 2 * x++ la: {0}", c);
            Console.WriteLine($"x = {x}");
            int y = 5;
            int d = 2 * ++y; // ++ ở trước y thì y tăng rồi thực hiện phép toán
            Console.WriteLine("Ket qua cua bieu thuc c = 2 * ++x la: {0}", d);
            Console.WriteLine($"y = {y}");
        }
    }
}