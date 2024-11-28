namespace CS42
{
    class Program42
    {
        public static void Run()
        {
            ParallelFor();
        }
        //In thông tin, Task ID và thread ID đang chạy
        public static void PintInfo(string info) =>
                Console.WriteLine($"{info,10}    task:{Task.CurrentId,3}    " +
                                  $"thread: {Thread.CurrentThread.ManagedThreadId}");
        public static void RunTask(int i)
        {
            PintInfo($"Start {i,3}");
            Task.Delay(1000).Wait();          
            PintInfo($"Finish {i,3}");
        }

        public static void ParallelFor()
        {
            // Chạy song song tác vụ
            ParallelLoopResult result = Parallel.For(1, 10, RunTask);  
            // Kiểm tra xem các tác vụ hoàn thành hay chưa
            Console.WriteLine($"Trang thai: {result.IsCompleted}");
        }
        
    }
}