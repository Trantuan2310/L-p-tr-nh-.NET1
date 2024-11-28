namespace CS32
{
    class Program32
    {
        public static void Run()
        {
            // SortedList<Tkey,TValue>
            var products = new SortedList<string, string>();
            products.Add("Iphone 6", "P-IPHONE-6"); // Thêm vào phần tử mới (key, value)
            products.Add("Laptop Abc", "P-LAP");
            products["Dien thoai Z"] = "P-DIENTHOAI"; // Thêm vào phần tử bằng Indexer
            products["Tai nghe XXX"] = "P-TAI";

            // Duyệt qua các phần tử, mỗi phần tử lấy key/value lưu trong biến
            // kiểu KeyValuePair
            Console.WriteLine("TEN VA MA");
            foreach (KeyValuePair<string, string> p in products)
            {
                Console.WriteLine($"    {p.Key} - {p.Value}");
            }
            
            // Đọc value khi biết key
            string productName = "Tai nghe XXX";
            Console.WriteLine($"{productName} có mã là {products[productName]}");

            // Cập nhật giá trị vào phần tử theo key
            products[productName] = "P-TAI-UPDATED";

            // Duyệt qua các giá trị
            Console.WriteLine("\nDANH SACH MA SP");
            foreach (var product_code in products.Values)
            {
                Console.WriteLine($"--- {product_code}");
            }

            // Duyệt qua các key
            Console.WriteLine("\nDANH SACH TEN SP");
            foreach (var product_name in products.Keys)
            {
                Console.WriteLine($"... {product_name}");
            }
        }
    }
}