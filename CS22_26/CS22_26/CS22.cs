using static CS22.Program22;

namespace CS22
{
    class Program22
    {
        public static void Run()
        {
            ShowLog showLog;
            
            showLog = Info;         // showLog gán bằng phương thức Info
            showLog("Thong tin\n");

            showLog = null;
            showLog += Warning;     // Gán nhiều phương thức vào delegate
            showLog += Info;
            showLog += Warning;      
            showLog("Canh bao");
            Console.WriteLine();

            ShowLog showLog1 = (x) => { Console.WriteLine($"-----{x}-----"); };
            ShowLog showLog2 = Warning;
            ShowLog showLog3 = Info;
            var all = showLog1 + showLog2 + showLog3 + showLog1;
            all("Xin Chao");
            Console.WriteLine();

            FuncAction.TestFunc(2, 5);
            Console.WriteLine();

            TinhTong(5, 6, (x) => Console.WriteLine($"Tong hai so la: {x}"));
            TinhTong(1, 3, Info);
        }

        // Khai báo delegate
        public delegate void ShowLog(string message);

        // Phương thức tương đồng với delegate
        public static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Info: {0}", s);
            Console.ResetColor();
        }

        // Phương thức tương đồng với delegate
        public static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Waring: {0}", s);
            Console.ResetColor();
        }
        class FuncAction // Func
        {
            static int Sum(int x, int y)
            {
                return x + y;
            }
            public static void TestFunc(int x, int y)
            {
                // Func<kiểu_tham_số_1, kiểu_tham_số_2, ..., kiểu_trả_về> var_delegate;        
                Func<int, int, int> tinhtong;
                tinhtong = Sum;                     

                var ketqua = tinhtong(x, y);
                Console.WriteLine($"Ket qua:{ketqua}");
            }
        }
        // Action tương tự như Func, điều khác duy nhất là nó không có kiểu trả về
        //  Action có thể gán bằng các hàm có kiểu trả về void

        // Sử dụng Delegate làm tham số hàm
        public static void TinhTong(int a, int b, Action<string> callback)
        {
            int c = a + b;        
            callback(c.ToString());
        }
    }
}