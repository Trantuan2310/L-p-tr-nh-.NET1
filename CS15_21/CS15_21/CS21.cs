namespace CS21
{
    class Program21
    {
        public static void Run()
        {
            var p1 = new Product();
            var p2 = new Iphone();
            p1.TestProduct();
            p2.TestProduct();

            var p3 = new Iphone1();
            var p4 = new Laptop();
            p3.TestProduct();
            p4.TestProduct();

            var p5 = new Product3(1000);
            p5.ShowPrice();
            p5.OrderAction(4);
        }
    }
    class Product // Phương thức ảo
    {
        protected double price = 0;
        public virtual void ProductInfo() // Muốn một phương thức là ảo, thêm từ khóa virtual vào khai báo tên hàm
        {
            Console.WriteLine($"Gia san pham {price}");
        }
        public void TestProduct()
        {
            this.ProductInfo();
        }
    }
    class Iphone : Product // Nạp chồng phương thức
    {
        public Iphone()
        {
            price = 500;
        }
        public override void ProductInfo()
        {
            Console.WriteLine($"Diem thoai Iphone");
            base.ProductInfo();
        }
    }

    abstract class Product1 // Lớp trừu tượng / Phương thức trừu tượng
    {
        protected double price = 0;
        public abstract void ProductInfo1();
        public void TestProduct()
        {
            this.ProductInfo1();
        }
    }
    class Iphone1 : Product1
    {
        public Iphone1()
        {
            price = 700;
        }
        public override void ProductInfo1()
        {
            Console.WriteLine($"Diem thoai Iphone");
        }
    }
    class Laptop : Product1
    {
        public Laptop()
        {
            price = 1500;
        }
        public override void ProductInfo1()
        {
            Console.WriteLine($"May Laptop");
        }
    }

    interface IProduct // Giao diện - Interface
    {
        public void ShowPrice();
    }
    interface IOrder
    {
        public void OrderAction(int numberProduct);
    }
    class Product3 : IProduct, IOrder
    {
        double price;
        public Product3(double price)
        {
            this.price = price;
        }
        public void ShowPrice()
        {
            Console.WriteLine($"Price: {price}");
        }

        public void OrderAction(int numberProduct)
        {
            Console.WriteLine($"Order: {numberProduct}");
        }
    }
}