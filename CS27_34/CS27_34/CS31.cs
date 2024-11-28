namespace CS31
{
    class Program31
    {
        public static void Run()
        {
            // RUN PHASE 1
            Product product1 = new Product(1, "Laptop", 1000, "USA");
            Product product2 = new Product(2, "Smartphone", 800, "China");
            Product product3 = new Product(3, "Tablet", 600, "Germany");

            Console.WriteLine("So sanh gia Laptop voi Smartphone: " + product1.CompareTo(product2)); 
            Console.WriteLine("So sanh gia Tablet voi Smartphone: " + product3.CompareTo(product2));
            Console.WriteLine();

            Console.WriteLine($"Thong tin san pham 1:{product1.ToString()}"); 
            Console.WriteLine($"Thong tin san pham 2:{product2.ToString()}");
            Console.WriteLine();

            Console.WriteLine($"Thong tin chi tiet (Xuat xu truoc):\n{product1.ToString("O")}");

            Console.WriteLine($"Thong tin chi tiet (Ten truoc):\n{product2.ToString("N")}");

            List<Product> products = new List<Product> { product1, product2, product3 };
            Console.WriteLine();
            // RUN PHASE 1

            // PHASE 2 & RUN PHASE 2
            // Thêm sản phẩm mới vào danh sách
            Product product4 = new Product(4, "Smartwatch", 300, "Japan");
            products.Add(product4);

            Console.WriteLine("Danh sach san pham sau khi them Smartwatch: ");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString("N"));
            }
            Console.WriteLine();

            // Chèn sản phẩm vào danh sách
            Product product5 = new Product(5, "Headphones", 200, "South Korea");
            products.Insert(1, product5); // Chèn vào vị trí thứ 2

            Console.WriteLine("Danh sach san pham sau khi chen Headphones:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString("N"));
            }
            Console.WriteLine();

            // Đọc sản phẩm trong mảng
            Product firstProduct = products[0]; // Đọc phần tử đầu tiên trong danh sách
                                                // sử dụng chỉ số
            Console.WriteLine("Phan tu dau tien trong danh sach: " + firstProduct.ToString("N"));

            Product secondProduct = products.ElementAt(1); // Đọc phần tu thu hai trong danh sách
                                                           // sử dụng ElementAt
            Console.WriteLine("Phan tu thu hai trong danh sach: " + secondProduct.ToString("N"));

            // Xóa sản phẩm trong danh sách
            products.Remove(product4); // Xóa sản phẩm theo đối tượng
            //products.RemoveAt(0); // Xóa sản phẩm theo chỉ số
            Console.WriteLine("\nDanh sach san pham sau khi xoa:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString("N"));
            }
            Console.WriteLine();
            // PHASE 2 & RUN PHASE 2

            // PHASE 3 & RUN PHASE 3
            // Tìm kiếm trong mảng
            Product findProduct = products.Find(p => p.Price > 700); 
            Console.WriteLine("San pham co gia > 700: " + (findProduct != null ? findProduct.Name : "Không tìm thấy"));

            // Sắp xếp các phần tử trong mảng
            products.Sort();

            Console.WriteLine("\nDanh sach san pham sap xep theo gia giam dan:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString("N"));
            }
            // PHASE 3 & RUN PHASE 3
        }
        // PHASE 1
        public class Product : IComparable<Product>, IFormattable
        // IComparable<Product>: Dùng để so sánh hai đối tượng Product
        // IFormattable: Dùng để định dạng và lấy thông tin sản phẩm
        // theo các định dạng khác nhau.
        {
            public int ID { set; get; }
            public string Name { set; get; }        
            public double Price { set; get; }      
            public string Origin { set; get; }      

            public Product(int id, string name, double price, string origin)
            {
                ID = id; Name = name; Price = price; Origin = origin;
            }
            public int CompareTo(Product other) // CompareTo được triển khai từ IComparable<Product>
                                                // dùng để so sánh hai sản phẩm dựa trên giá (Price)
            {
                double delta = this.Price - other.Price;
                if (delta > 0)      
                    return -1; // Nếu giá sp hiện tại lớn hơn thì xếp trước
                               // ngược lại thì xếp sau
                else if (delta < 0)
                    return 1;
                return 0;

            }
            public string ToString(string format, IFormatProvider formatProvider)
            // ToString được nạp chồng để trả về thông tin của sản phẩm dưới dạng chuỗi
            {
                if (format == null) format = "O";
                switch (format.ToUpper())
                {
                    case "O": 
                        return $"Nguon oc: {Origin} - Ten: {Name} - Gia: {Price} - ID: {ID}";
                    case "N": 
                        return $"Ten: {Name} - Nguon goc: {Origin} - Gia: {Price} - ID: {ID}";
                    default: 
                        throw new FormatException("Khong ho tro format nay");
                }
            }

            override public string ToString() => $"{Name} - {Price}";

            public string ToString(string format) => this.ToString(format, null);

        }
        // PHASE 1
    }
}