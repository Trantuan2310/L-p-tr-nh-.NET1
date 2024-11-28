using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS52
{
    public class ProductDbContext52 : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product52> products { get; set; }

        private const string connectionString = @"
            Data Source=.\SQLEXPRESS;
            Initial Catalog=data52; 
            User ID=sa; 
            Password=1234;
            Encrypt = false";            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}