namespace CS07
{
    class Program07
    {
        public static void Run()
        {
            // Khai báo mảng, khởi tạo mảng
            int[] myArray = { 3, 8, 2, 4, 1, 9 };

            // Truy cập các phần tử mảng
            Console.WriteLine($"Phan tu thu 3 cua mang: {myArray[2]}");

            // Thuộc tính và phương thức của đối tượng mảng
            Console.WriteLine($"So luong phan tu cua mang:{myArray.Length}");
            Console.WriteLine($"So chieu cua mang:{myArray.Rank}");
            Console.WriteLine($"Phan tu thu 6 cua mang:{myArray.GetValue(5)}");
            Console.WriteLine($"Gia tri nho nhat cua mang:{myArray.Min()}");
            Console.WriteLine($"Gia tri lon nhat cua mang:{myArray.Max()}");
            Console.WriteLine($"Tong cac phan tu cua mang:{myArray.Sum()}");

            // Duyệt qua các phần tử mảng
            Console.WriteLine("Cac phan tu trong mang: ");
            for (int i = 0; i <= myArray.Length - 1; i++)
            {
                Console.WriteLine(myArray[i]);
            }

            // Mảng nhiều chiều
            Console.WriteLine("Cac phan tu trong mang 01: ");
            int[,] myArray1 = new int[3, 3] { { 3, 8, 2 }, { 4, 1, 9 }, { 1, 6, 1 } };
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    Console.Write(myArray1[x, y] + " ");
                }
                Console.WriteLine();
            }

            // Mảng trong mảng jagged
            Console.WriteLine("Cac phan tu trong mang 02: ");
            int[][] myArray2 = new int[][] {
                                new int[] {1,2},
                                new int[] {2,5,6},
                                new int[] {2,3},
                                new int[] {2,3,4,5,5}
                               };
            foreach (var arr in myArray2)
            {
                foreach (var e in arr)
                {
                    Console.Write(e + " ");
                }
                Console.WriteLine();
            }
        }
    }
}