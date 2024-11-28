using Microsoft.EntityFrameworkCore;

namespace CS55
{
    class Program55
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext55();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var kq = dbcontext.Database.EnsureCreated();

            if (kq)
            {
                Console.WriteLine($"Create {dbname} successfully");
            }
            else
            {
                Console.WriteLine($"Create {dbname} failed");
            }
        }
        static void DropDatabase()
        {
            using var dbcontext = new ShopContext55();
            string dbname = dbcontext.Database.GetDbConnection().Database;

            var kq = dbcontext.Database.EnsureDeleted();

            if (kq)
            {
                Console.WriteLine($"Delete {dbname} successfully");
            }
            else
            {
                Console.WriteLine($"Delete {dbname} failed");
            }
        }
        static void InsertData()
        {
            using var dbcontext = new ShopContext55();

            Category55 c1 = new Category55() { Name = "Phone", Description = "Listen, call,..." };
            Category55 c2 = new Category55() { Name = "Clothes", Description = "Keep warm, cover,..." };

            dbcontext.categorys.Add(c1);
            dbcontext.categorys.Add(c2);

            // Sử dụng LazyLoading nên không cần
            //var c1 = (from c in dbcontext.categorys where c.CategoryId == 1 select c).FirstOrDefault();
            //var c2 = (from c in dbcontext.categorys where c.CategoryId == 2 select c).FirstOrDefault();

            dbcontext.Add(new Product55() { Name = "Iphone", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product55() { Name = "Samsung", Price = 800, Category55 = c1 });
            dbcontext.Add(new Product55() { Name = "Xiaomi", Price = 300, CateId = 1 });
            dbcontext.Add(new Product55() { Name = "Shirt", Price = 100, CateId = 2 });
            dbcontext.Add(new Product55() { Name = "Nokia", Price = 350, Category55 = c1 });
            dbcontext.Add(new Product55() { Name = "Jacket", Price = 200, Category55 = c2 });
            dbcontext.Add(new Product55() { Name = "sweater", Price = 250, Category55 = c2 });

            dbcontext.SaveChanges();
        }
        public static async Task Run()
        {
            //DropDatabase();
            CreateDatabase();
            InsertData();

            // PHASE 1 TRUY VẤN CƠ BẢN
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Truy van co ban");
            Console.ResetColor();

            // Truy vấn dữ liệu trực tiếp từ các DbSet
            using var context = new ShopContext55();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Products in the Produt55 category: ");
            Console.ResetColor();

            var product = context.products;
            foreach (var pro in product)
            {
                Console.WriteLine(pro.Name);
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Products priced > 100: ");
            Console.ResetColor();

            var product1 = context.products
                .Where(p => p.Price > 100)
                .OrderByDescending(p => p.Price);
            foreach (var pro in product1)
            {
                Console.WriteLine($"Name: {pro.Name} - {pro.Price}");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter product id: ");
            Console.ResetColor();

            int id = int.Parse(Console.ReadLine());

            var product2 = await context.products.FindAsync(id);
            if (product2 != null)
            {
                Console.WriteLine($"Product with id = {id} is: {product2.Name}");
            }
            else
            {
                Console.WriteLine("Product not exist");
            }
            Console.WriteLine();


            // Truy vấn kết hợp nhiều bảng với join
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Using inner join");
            Console.ResetColor();

            var product3 = from p in context.products
                           join c in context.categorys on p.CateId equals c.CategoryId
                           select new
                           {
                               tensanpham = p.Name,
                               gia = p.Price,
                               danhmuc = c.Name
                           };
            foreach (var item in product3)
            {
                Console.WriteLine($"Name:{item.tensanpham} - Price:{item.gia} " +
                    $"- Category:{item.danhmuc}");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Using left join");
            Console.ResetColor();
            var product4 = from p in context.products
                           join c in context.categorys on p.CateId02 equals c.CategoryId
                           into t
                           from cate2 in t.DefaultIfEmpty()
                           select new
                           {
                               tensanpham = p.Name,
                               gia = p.Price,
                               danhmuc = (cate2 == null) ? "Not exist" : cate2.Name
                           };
            foreach (var item in product4)
            {
                Console.WriteLine($"Name:{item.tensanpham} - Price:{item.gia} " +
                    $"- Category:{item.danhmuc}");
            }
            Console.WriteLine();
// PHASE 1 TRUY VẤN CƠ BẢN

// PHASE 2 RAW QUERY
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Truy van voi Raw Query");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Product price decreasing: ");
            Console.ResetColor();

            String sql = "SELECT * FROM products ORDER BY CAST(Price AS DECIMAL) DESC;";
            var product5 = context.products.FromSqlRaw(sql);

            foreach (var pro in product)
            {
                Console.WriteLine($"{pro.Name} - {pro.Price}");
            }
            Console.WriteLine();
// PHASE 2 RAW QUERY

// PHASE 3 HÀM TRONG EF
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ham trong EF");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter a character: ");
            String kytu = Console.ReadLine();
            Console.WriteLine($"Products with character {kytu}: ");
            Console.ResetColor();

            var product6 = await (from p in context.products
                                  where EF.Functions.Like(p.Name, $"%{kytu}%")
                                  select p)
                                  .ToListAsync();

            foreach (var pro in product6)
            {
                Console.WriteLine(pro.Name);
            }
// PHASE 3 HÀM TRONG EF
        }
    }
}