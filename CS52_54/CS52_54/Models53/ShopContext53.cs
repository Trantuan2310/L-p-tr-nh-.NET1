using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS53
{
    public class ShopContext53 : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product53> products { get; set; }
        public DbSet<Category53> categorys { get; set; }

        private const string connectionString = @"
            Data Source=.\SQLEXPRESS;
            Initial Catalog=shopdata53; 
            User ID=sa; 
            Password=1234;
            Encrypt = false";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseLazyLoadingProxies();
        }


    }
}