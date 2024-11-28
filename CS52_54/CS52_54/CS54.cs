using CS53;
using Microsoft.EntityFrameworkCore;

namespace CS54
{
    class Program54
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext54();
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
            using var dbcontext = new ShopContext54();
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
            using var dbcontext = new ShopContext54();

            Category54 c1 = new Category54() { Name = "Phone", Description = "Listen, call,..." };
            Category54 c2 = new Category54() { Name = "Clothes", Description = "Keep warm, cover,..." };

            dbcontext.categorys.Add(c1);
            dbcontext.categorys.Add(c2);

            // Sử dụng LazyLoading nên không cần
            //var c1 = (from c in dbcontext.categorys where c.CategoryId == 1 select c).FirstOrDefault();
            //var c2 = (from c in dbcontext.categorys where c.CategoryId == 2 select c).FirstOrDefault();

            dbcontext.Add(new Product54() { Name = "Iphone", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product54() { Name = "Samsung", Price = 800, Category54 = c1 });
            dbcontext.Add(new Product54() { Name = "Xiaomi", Price = 300, CateId = 1 });
            dbcontext.Add(new Product54() { Name = "Shirt", Price = 100, CateId = 2 });
            dbcontext.Add(new Product54() { Name = "Nokia", Price = 350, Category54 = c1 });
            dbcontext.Add(new Product54() { Name = "Jacket", Price = 200, Category54 = c2 });
            dbcontext.Add(new Product54() { Name = "sweater", Price = 250, Category54 = c2 });

            dbcontext.SaveChanges();
        }
        public static void Run()
        {
            DropDatabase();
            //CreateDatabase();
            //InsertData();
        }
    }
}