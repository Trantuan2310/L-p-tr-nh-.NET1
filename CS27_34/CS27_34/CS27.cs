namespace CS27
{
    class Program27
    {
        public static void Run()
        {
            try // Exception
            {
                int[] Numbers = new int[] { 1, 2, 3, 4, 5 };
                int i = Numbers[5]; // Báo lỗi, mảng chỉ có 4 phần tử
                Console.WriteLine($"Phan tu cua mang: {i}");
                Console.WriteLine();
            }
            catch (Exception e) // Thực thi khi có lỗi
            {
                Console.WriteLine("Phat hien loi");
                Console.WriteLine(e.Message); // Hiển thị lỗi
                Console.WriteLine();
            }

            int x = 10;
            int y = 2;
            int z = 0;
            try // Nhiều Exception
            {               
                z = x / y;
            }
            catch (DivideByZeroException e1) // Thực thi khi chia một số cho 0
            {
                Console.WriteLine(e1.Message);
                Console.WriteLine();
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message); // Thực thi khi có các ngoại lệ khác
                Console.WriteLine();
            }
            finally // Thêm finally, luôn được thực thi
            {
                Console.WriteLine($"Ket qua: {z}");
                Console.WriteLine();
            }

            double c = Thuong(100, 50); // Nếu thay 50 = 0 thì chương trình sẽ dừng
                                        // ngay lập tức
            Console.WriteLine($"Ket qua phep chia: {c}");
            Console.WriteLine();

            //try
            //{
            //    double c = Thuong(100, 0);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine();
            //}

            try
            {
                UserInput("Day la mot chuoi"); // Nếu chuỗi ngắn hơn 10 thì in ra
                                               // màn hình
            }
            catch (LongExeption e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception otherExeption)
            {
                Console.WriteLine(otherExeption.Message);
            }
        }
        public static double Thuong(double a, double b)
        {
            if (b == 0)
            {
                Exception myexception = new Exception("So chia khong duoc bang 0");

                throw myexception; // Throw, phát sinh ngoại lệ thì code 
            }                      // Phía sau không được thực thi 
            return a / b;          // Run 44 
        }

        public class LongExeption : Exception // Tạo Exeption riêng
        {
            const string erroMessage = "Du lieu qua dai";
            public LongExeption() : base(erroMessage)
            {
            }
        }
        public static void UserInput(string s)
        {
            if (s.Length > 10)
            {
                Exception e = new LongExeption();
                throw e;    // Run 56
            }
            else
            {
                Console.WriteLine(s);
            }          
        }
    }
}