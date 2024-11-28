namespace CS02
{
    class Program02
    {
        public static void Run()
        {
            // Kiểu dữ liệu và gán giá trị cho biến
            string userName = "Nguyen Van A";
            Console.WriteLine(userName);
            int userAge;
            userAge = 21;
            Console.WriteLine($"Tuoi: {userAge}");
            Console.WriteLine();
            
            // Nhập, xuất dữ liêu
            string hovaten;
            Console.Write("Nhap vao ho va ten: ");
            hovaten = Console.ReadLine();
            Console.WriteLine("Xin chao {0}", hovaten);
            Console.WriteLine();
            
            // Chuyển đổi kiểu dữ liệu
            float a, b;
            string sinput;
            Console.Write("Nhap so a: ");
            sinput = Console.ReadLine();
            a = float.Parse(sinput);

            Console.Write("Nhap so b: ");
            sinput = Console.ReadLine();
            b = Convert.ToSingle(sinput);

            Console.WriteLine("So a = {0}, b = {1}", a, b);
            Console.WriteLine();

        }
    }
}