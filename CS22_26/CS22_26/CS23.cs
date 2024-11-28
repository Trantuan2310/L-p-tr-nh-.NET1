namespace CS23
{
    class Program23
    {
        // khai báo lambda 
        // (các_tham_số) => biểu thức;
        // (các_tham_số) => { khối lệnh }
        public delegate int TinhToan(int a, int b);

        public static void Run() 
        {
            // Gán lambda cho delegate
            TinhToan tinhtong = (int x, int y) => { 
                return x + y;
            };

            int kq = tinhtong(2, 3); 
            Console.WriteLine($"Ket qua: {kq}");

            //Gán lambda cho Func
            Func<int, int, int> tinhtong1 = (int x, int y) => {
                return x + y;
            };

            // Gán lambda cho Action
            Action<int> thongbao = (int v1) => {
                Console.WriteLine(v1);
            };

            int kq1 = tinhtong1(5, 3); 
            thongbao(kq1);           
        }
    }
}