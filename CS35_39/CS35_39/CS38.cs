using System.Net;

namespace CS38
{
    class Program38
    {
        public static async Task Run()
        {
            // RUN PHASE 1
            TestDownloadWebpage();
            // RUN PHASE 1

            //RUN PHASE 2
            Console.WriteLine($"MainThread: {Thread.CurrentThread.ManagedThreadId}");
            Task<string> t1 = TestAsync01.Async1("A","B");
            Task t2 = TestAsync01.Async2();

            Console.WriteLine("Bat dau chay song song");
            // Chờ t1 kết thúc và đọc kết quả trả về
            t1.Wait();
            String s = t1.Result;
            TestAsync01.WriteLine(s, ConsoleColor.Red);

            // Ngăn không cho thread chính kết thúc
            // Nếu thread chính kết thúc mà t2 đang chạy nó sẽ bị ngắt
            Console.ReadKey();
            //RUN PHASE 2

            //RUN PHASE 3
            var t3 = TestAsyncAwait.Async1("x", "y");
            var t4 = TestAsyncAwait.Async2();

            // Làm gì đó khi t3, t4 đang chạy
            Console.WriteLine("Task1, Task2 đang chay");

            await t3; // chờ t3 kết thúc

            await t4; // chờ t4 kết thúc
            //RUN PHASE 3

        }
        // PHASE 1
        public static string DownloadWebpage(string url, bool showresult)
        {
            // Sử dụng WebClient để tải trang web
            using (var client = new WebClient())
            {
                Console.Write("Starting download ...");
                // Lưu trang web vào biến content
                string content = client.DownloadString(url);
                Thread.Sleep(3000); // Chờ 3s
                if (showresult)
                    Console.WriteLine(content.Substring(0, 150));

                return content;
            }
        }

        public static void TestDownloadWebpage()
        {
            string url = "https://code.visualstudio.com/";
            DownloadWebpage(url, true);
            Console.WriteLine("Do somthing ...");
        }
        // PHASE 1

        // PHASE 2
        public class TestAsync01
        {
            // Phương thức màu chữ
            public static void WriteLine(string s, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(s);
            }
            public static Task<string> Async1(string thamso1, string thamso2)
            {
                Func<object, string> myfunc = (object thamso) => { // lambda
                    dynamic ts = thamso;
                    for (int i = 1; i <= 3; i++) // Số lần lặp của Thread
                    {
                        WriteLine($"{i} {Thread.CurrentThread.ManagedThreadId} Tham so {ts.x} {ts.y}",
                        ConsoleColor.Green);
                        Thread.Sleep(500);
                    }
                    return $"Ket thuc Async1!";
                };

                Task<string> task = new Task<string>(myfunc, new { x = thamso1, y = thamso2 });
                task.Start(); // Chạy tác vụ trên Thread khác, không làm chặn chương trình chính

                Console.WriteLine("Async1: Lam gi do sau khi Task chay");


                return task;
            }

            public static Task Async2()
            {

                Action myaction = () => {
                    var originalColor = Console.ForegroundColor; // Lưu lại màu 
                    for (int i = 1; i <= 3; i++)
                    {
                        WriteLine($"{i} {Thread.CurrentThread.ManagedThreadId}",
                            ConsoleColor.Yellow);
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("Ket thuc Async2!");
                    Console.ForegroundColor = originalColor; // Khôi phục màu gốc
                };
                Task task = new Task(myaction);
                task.Start(); // Lệnh để chạy song song 

                Console.WriteLine("Async2: Lam gi do sau khi Task chay");

                return task;
            }

        }
        // PHASE 2

        //PHASE 3
        public class TestAsyncAwait
        {
            public static void WriteLine(string s, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(s);
            }
            public static async Task<string> Async1(string thamso1, string thamso2)
            {
                // tạo biến delegate trả về kiểu string, có một tham số object
                Func<object, string> myfunc = (object thamso) => {
                    // Đọc tham số (dùng kiểu động - xem kiểu động để biết chi tiết)
                    dynamic ts = thamso;
                    for (int i = 1; i <= 10; i++)
                    {
                        //  Thread.CurrentThread.ManagedThreadId  trả về ID của thread đạng chạy
                        WriteLine($"{i} {Thread.CurrentThread.ManagedThreadId} Tham so {ts.x} {ts.y}",
                            ConsoleColor.Green);
                        Thread.Sleep(500);
                    }
                    return $"Ket thuc Async1!";
                };

                Task<string> task = new Task<string>(myfunc, new { x = thamso1, y = thamso2 });
                task.Start();  // chý ý dòng này, để đảm bảo  task được kích hoạt

                await task;


                // Từ đây là code sau await (trong Async1) sẽ chỉ thi hành khi task kết thúc
                TestAsync01.WriteLine("Async1", ConsoleColor.Red);
                string ketqua = task.Result;       // Đọc kết quả trả về của task - không phải lo block thread gọi Async1

                Console.WriteLine(ketqua);        // In kết quả trả về của task
                return ketqua;
            }

            public static async Task Async2()
            {
                var originalColor = Console.ForegroundColor; // Lưu lại màu 
                Action myaction = () => {
                    for (int i = 1; i <= 10; i++)
                    {
                        WriteLine($"{i} {Thread.CurrentThread.ManagedThreadId}", ConsoleColor.Yellow);
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("Ket thuc Async2!");
                };
                Task task = new Task(myaction);
                task.Start();

                await task;

                // Làm gì đó sau khi chạy Task ở đây
                Console.WriteLine("Async2");
                Console.ForegroundColor = originalColor; // Khôi phục màu gốc

                // Không cần trả về vì gốc đồng bộ trả về void, đồng bộ sẽ trả về Task
            }
        }
        //PHASE 3
    }
}