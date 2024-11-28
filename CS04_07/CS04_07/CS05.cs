namespace CS05
{
    class Program05
    {
        public static void Run()
        {
            // Toán tử so sánh == > >= < <= = !=
            Console.Write("Nhap vao so a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao so b: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("a == b ==> {0}", a == b);
            Console.WriteLine("a > b ==> {0}", a > b);
            Console.WriteLine("a < b ==> {0}", a < b);
            Console.WriteLine("a >= b ==> {0}", a >= b);
            Console.WriteLine("a <= b ==> {0}", a <= b);
            Console.WriteLine("a != b ==> {0}", a != b);

            // Toán tử logic && || !
            bool x = true;
            bool y = false;
            Console.WriteLine("Ket qua cua x && y la: {0}", x && y);
            Console.WriteLine("Ket qua cua x || y la: {0}", x || y);
            Console.WriteLine("Ket qua cua !x la: {0}", !x);

            // Câu lệnh if else 
            Console.Write("Nhap vao diem trung binh: ");
            float dtb = float.Parse(Console.ReadLine());
            if (dtb < 5.0)
            {
                Console.WriteLine("Hoc luc yeu");
            }
            else if (dtb < 6.5)
            {
                Console.WriteLine("Hoc luc trung binh");
            }
            else if (dtb < 8.0)
            {
                Console.WriteLine("Hoc luc kha");
            }
            else if (dtb <= 10)
            {
                Console.WriteLine("Hoc luc gioi");
            }
            else
            {
                Console.WriteLine("Nhap sai so diem");
            }

            // Câu lệnh ba thành phần với toán tử
            Console.Write("Nhap vao so c: ");
            int c = int.Parse(Console.ReadLine());
            var max = a > b ? a > c ? a : c : b > c ? b : c;
            Console.WriteLine($"So lon nhat giua a, b, c la: {max}");

            // Câu lệnh rẽ nhánh switch
            Console.Write("Nhap vao mot so tu 1-10: ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 10)
            {
                switch (n)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 9:
                        Console.WriteLine("Day la so le");
                        break;
                    case 2:
                    case 4:
                    case 6:
                    case 8:
                    case 10:
                        Console.WriteLine("Day la so chan");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nhap sai");
            }

        }
    }
}