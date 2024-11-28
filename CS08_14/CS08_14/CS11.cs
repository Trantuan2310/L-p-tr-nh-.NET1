namespace CS11
{
    class Program11
    {
        public static void Run()
        {
            Product product1 = new Product();
            Console.WriteLine("Name : " + product1.name); // Gọi phương thức khởi tạo không tham số
            Console.WriteLine("Price: " + product1.price);

            Product product2 = new Product("Laptop", 123);
            Console.WriteLine("Name : " + product2.name); // Gọi phương thức khởi tạo có tham số
            Console.WriteLine("Price: " + product2.price);
        }

        class Product
        {
            public string name;
            public decimal price;

            public Product(string nameproduct, decimal priceproduct) // Có tham số truyền vào
            {
                name = nameproduct;
                price = priceproduct;
            }
            public Product() // Không có tham số truyền vào
            {
                name = "Không tên";
                price = 0;
            }           
        }
    }
}