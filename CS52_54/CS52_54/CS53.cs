using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CS53
{
    class Program53
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext53();
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
            using var dbcontext = new ShopContext53();
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
            using var dbcontext = new ShopContext53();

            Category53 c1 = new Category53() { Name = "Phone", Description = "Listen, call,..." };
            Category53 c2 = new Category53() { Name = "Clothes", Description = "Keep warm, cover,..." };

            dbcontext.categorys.Add(c1);
            dbcontext.categorys.Add(c2);

            // Sử dụng LazyLoading nên không cần
            //var c1 = (from c in dbcontext.categorys where c.CategoryId == 1 select c).FirstOrDefault();
            //var c2 = (from c in dbcontext.categorys where c.CategoryId == 2 select c).FirstOrDefault();

            dbcontext.Add(new Product53() { Name = "Iphone", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product53() { Name = "Samsung", Price = 800, Category53 = c1 });
            dbcontext.Add(new Product53() { Name = "Xiaomi", Price = 300, CateId = 1 });
            dbcontext.Add(new Product53() { Name = "Shirt", Price = 100, CateId = 2 });
            dbcontext.Add(new Product53() { Name = "Nokia", Price = 350, Category53 = c1 });
            dbcontext.Add(new Product53() { Name = "Jacket", Price = 200, Category53 = c2 });
            dbcontext.Add(new Product53() { Name = "sweater", Price = 250, Category53 = c2 });

            dbcontext.SaveChanges();
        }
        public static void Run()
        {
            //DropDatabase();
            CreateDatabase();
            InsertData();
            using var dbcontext = new ShopContext53();
            //Truy vấn Product
            //var category = (from c in dbcontext.categorys where c.CategoryId == 2 select c).FirstOrDefault();
            //Console.WriteLine($"{category.CategoryId} - {category.Name}");

            //var e = dbcontext.Entry(category);
            //e.Collection(c => c.Products).Load();

            //if (category.Products != null)
            //{
            //    Console.WriteLine($"Number of products: {category.Products.Count()}");
            //    category.Products.ForEach(p => p.PrintInfo());
            //}
            //else
            //{
            //    Console.WriteLine("Products == null");
            //}


            //var product = (from p in dbcontext.products where p.ProductId == 1 select p).FirstOrDefault();

            //var e = dbcontext.Entry(product);
            //e.Reference(p => p.Category53).Load();

            //product.PrintInfo();

            //if (product.Category53 != null)
            //{
            //    Console.WriteLine($"{product.Category53.Name} - {product.Category53.Description}");
            //}
            //else
            //{
            //    Console.WriteLine("Category == null");
            //}

            // Sử dụng CateId02 ở Product53.cs
            //var category = (from c in dbcontext.categorys where c.CategoryId == 1 select c).FirstOrDefault();
            //dbcontext.Remove(category);
            //dbcontext.SaveChanges();

            // Sử dụng LINQ (comment LazyLoading)
            //var p = dbcontext.products.Find(6);
            //p.PrintInfo();

            //var products = from p in dbcontext.products
            //               where p.Price >= 400
            //               select p;
            //products.ToList().ForEach(p => p.PrintInfo());

        }
    }
}