namespace CS37
{
    class Program37
    {
        public static void Run()
        {
            var brands = new List<Brand>() 
            {
                new Brand{Name = "Cong ty A", ID = 1},
                new Brand{ID = 2, Name = "Cong ty B"},
                new Brand{ID = 4, Name = "Cong ty C"},
            };
            var products = new List<Product>()
            {
                new Product(1, "Ban hoc", 400, "Xám", 2),
                new Product(2, "Tranh", 400, "Vàng", 1),
                new Product(3, "Den", 100, "Trắng", 3),
                new Product(4, "Ban", 500, "Trắng", 1),
                new Product(5, "Tui", 150, "Đen", 2)
            };
            
            var ketqua = from product in products // Xác định nguồn dữ liệu products
                         where product.Price == 400
                         select product;
            foreach (var product in ketqua)
            Console.WriteLine(product.ToString());
        }
        public class Product
        {
            public int ID { set; get; }
            public string Name { set; get; }         
            public double Price { set; get; }        
            public string Colors { set; get; }     
            public int Brand { set; get; }           
            public Product(int id, string name, double price, string colors, int brand)
            {
                ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
            }
            override public string ToString()
               => $"ID:{ID} - Name:{Name} - Price:{Price} - Color:{Colors} - Brand:{Brand}";
        }
        public class Brand
        {
            public string Name { set; get; }
            public int ID { set; get; }
        }
    }
}