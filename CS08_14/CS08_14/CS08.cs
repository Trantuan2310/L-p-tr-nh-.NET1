namespace CS08
{
    class Program08
    {
        public static void Run()
        {
            int Ketqua = Tich(3, 4);
            Console.WriteLine($"Tich cua hai so: {Ketqua}");

            int Ketqua1 = Class1.Tong(5, 5);
            Console.WriteLine("Tong cua hai so la: " + Ketqua1);

            Console.WriteLine("Xin chao" + " " + Class2.FullName("Nguyen Van", "A"));

            int x = 2;

            Class3.ThamTri(x);
            Console.WriteLine("Tham so sau khi tham tri: " + x);
            Class3.ThamChieu(ref x);
            Console.WriteLine("Tham so sau khi tham chieu: " + x);

            int y = 6;
            Console.Write("Giai thua cua 6 la: " + Class4.GiaiThua(y));
        }
        public static int Tich(int a, int b)
        {
            return a * b;
        }

        // Gọi phương thức
        public class Class1
        {
            public static int Tong(int x, int y)
            {
                return x + y;
            }
        }

        // Tham số trong phương thức
        // Có thể có or không 

        // Tham số có giá trị mặc định
        // Gán giá trị cho tham số bằng phép gán =

        // Truyền tham số với tên
        public class Class2
        {
            public static string FullName(string ho, string ten)
            {
                string fullname = ho + " " + ten;
                return fullname;
            }
        }

        // Tham chiếu và tham trị
        public class Class3
        {
            public static void ThamTri(int x)
            {
                x = x * x;
                Console.WriteLine(x);
            }
            public static void ThamChieu(ref int y)
            {
                y = y * y;
                Console.WriteLine(y);
            }
        }

        // Đệ quy
        public class Class4
        {
            public static int GiaiThua(int a)
            {
                if (a == 1)
                    return 1;

                return
                    a * GiaiThua(a - 1);
            }
        }
    }
}