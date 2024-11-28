using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CS52
{
    class Program52
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ProductDbContext52();
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
            using var dbcontext = new ProductDbContext52();
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
        static void InsertProduct()
        {
            using var dbcontext = new ProductDbContext52();

            var p1 = new Product52();
            {
                p1.ProductName = "Product 1";
                p1.Provider = "Company 1";
            }
            dbcontext.Add(p1);

            var products = new object[]
            {
                new Product52(){ProductName = "Product 2", Provider = "Company 2"},
                new Product52(){ProductName = "Product 3", Provider = "Company 3"},
                new Product52(){ProductName = "Product 4", Provider = "Company 4"},
                new Product52(){ProductName = "Product 5", Provider = "Company 5"},
            };
            dbcontext.AddRange(products);

            int number_rows = dbcontext.SaveChanges();
            Console.WriteLine($"Inserted {number_rows} data");
        }
        static void ReadProduct()
        {
            using var dbcontext = new ProductDbContext52();

            var products = dbcontext.products.ToList();
            products.ForEach(product => product.PrintInfo());

            var qr = from product in dbcontext.products
                     where product.ProductId >= 3
                     select product;
            qr.ToList().ForEach(product => product.PrintInfo());
        } 
        static void RenameProduct(int id, string newName)
        {
            using var dbcontext = new ProductDbContext52();
            Product52 product = (from p in dbcontext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if( product != null )
            {
                //EntityEntry<Product> entry = dbcontext.Entry(product);
                //entry.State = EntityState.Deleted;
                product.ProductName = newName;
                int number_rows = dbcontext.SaveChanges();
                Console.WriteLine($"Inserted {number_rows} data");
            }
            else
            {
                Console.WriteLine($"Product with code {id} does not exist");
            }
        }
        static void DeleteProduct(int id)
        {
            using var dbcontext = new ProductDbContext52();
            Product52 product = (from p in dbcontext.products
                               where p.ProductId == id
                               select p).FirstOrDefault();
            if (product != null)
            {
                    dbcontext.Remove( product );
                    int number_rows = dbcontext.SaveChanges();
                Console.WriteLine($"Deleted {number_rows} data");
            }
            else
            {
                Console.WriteLine($"Product with code {id} does not exist");
            }
        }
        public static void Run()
        {
            CreateDatabase();
            //DropDatabase();
            InsertProduct();
            //ReadProduct();
            //RenameProduct(1, "Laptop");
            //DeleteProduct(1);
        }
    }
}