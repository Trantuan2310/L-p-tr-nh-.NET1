namespace CS20
{
    class Program20
    {
        public static void Run()
        {
            // null chỉ có thể gán được cho các biến kiểu tham chiếu
            // null không gán cho những biến có kiểu dữ liệu dạng tham trị 

            int? bien; // Khai báo biến có khả năng nullable để có thể gán null
            bien = null;
            bien = 10;

            if (bien != null)
            {
                Console.WriteLine($"Gia tri cua bien: {bien}");
            }
            else
            {
                Console.WriteLine("Bien co gia tri la null"); // Có thể thay đổi biến thành null để else xảy ra
            }
        }
    }
}