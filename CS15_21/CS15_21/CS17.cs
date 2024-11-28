namespace CS17
{
    class Program17
    {
        public static void Run()
        {
            var SanPham = new Product();
            SanPham.Name = "Ao";
            SanPham.Price = 100; // Gọi đến class Product ở file Class2
            SanPham.ShowName();
            SanPham.ShowPrice();
            var SanPham1 = new Product.Product1();
            SanPham1.ShowInfo();
        }
    }
    public partial class Product // Sử dụng partial
    {
        public string Name;
        public void ShowName()
        {
            Console.WriteLine($"Name: {Name}");
        }
        public class Product1 // Lớp lồng nhau
        {
            string name = "Ao";
            float price = 70;
            public void ShowInfo()
            {
                Console.WriteLine($"Name: {name}\nPrice:{price}");
            }
        }
    }
}