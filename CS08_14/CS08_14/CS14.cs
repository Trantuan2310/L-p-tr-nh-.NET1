namespace CS14
{
    class Program14
    {
        public static void Run()
        {
            Product productA;
            productA.name = "Iphone";
            productA.price = 1000;

            Product productB = productA;
            productB.name = "Laptop";

            Console.WriteLine(productA.ToString());
            Console.WriteLine(productB.ToString());

            int a = (int)HocLuc.Kha;
            Console.WriteLine(a);

            HocLuc hoc = (HocLuc)2; // Có thể cast - chuyển kiểu qua lại giữa enum và int
            Console.WriteLine(hoc);
        }

        public struct Product
        {
            public string name;
            public decimal price;
            public override string ToString() => $"{name} : {price}$";
        }

        // Sử dụng enum
        enum HocLuc { Kem, TrungBinh, Kha, Gioi } // Các giá trị tương ứng 0 1 2 3
    }
}