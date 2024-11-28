using System.ComponentModel;

namespace CS33
{
    class Program33
    {
        public static void Run()
        {
            // Hàng đợi Queue (vào trước - ra trước)
            // Enqueue	vào xếp hàng - đưa phần tử vào cuối hàng đợi
            Queue<string> hoso_canxuly = new Queue<string>();

            hoso_canxuly.Enqueue("Ho so A"); // Hồ sơ xếp thứ nhất trong hàng đợi
            hoso_canxuly.Enqueue("Ho so B"); // Hồ sơ xếp thứ hai
            hoso_canxuly.Enqueue("Ho so C");

            while (hoso_canxuly.Count > 0) // Count lấy tổng số phần tử trong hàng
            {
                var hs = hoso_canxuly.Dequeue(); // Dequeue	đọc và loại ngay phần tử ở đầu hàng đợi
                                                 // lỗi nếu hàng đợi không có phần tử nào
                Console.WriteLine($"Xu ly {hs}, con lai {hoso_canxuly.Count}");
            }
            // Peek	đọc phần tử đầu hàng đợi
            // Hàng đợi Queue 

            // Ngăn xếp Stack (vào sau - ra trước)
            Stack<string> congviec_canxuly = new Stack<string>();

            congviec_canxuly.Push("Cong viec A"); // Push đẩy (thêm) một phần tử vào đỉnh stack
            congviec_canxuly.Push("Cong viec B"); 
            congviec_canxuly.Push("Cong viec C"); 

            while (congviec_canxuly.Count > 0)
            {
                var hs = congviec_canxuly.Pop(); // Pop	đọc - xóa phần tử đỉnh stack
                Console.WriteLine($"Xu ly {hs}, con lai {congviec_canxuly.Count}");
            }
            // Peek	đọc phần tử đỉnh stack
            // Contains kiểm tra một phần tử có trong stack hay không
            // Ngăn xếp Stack
        }
    }
}