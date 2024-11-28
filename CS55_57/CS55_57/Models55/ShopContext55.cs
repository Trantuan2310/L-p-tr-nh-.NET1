using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS55
{
    public class ShopContext55 : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product55> products { get; set; }
        public DbSet<Category55> categorys { get; set; }

        private const string connectionString = @"
            Data Source=.\SQLEXPRESS;
            Initial Catalog=shopdata55; 
            User ID=sa; 
            Password=1234;
            Encrypt = false";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product55>(entity =>
            {
                // Table mapping
                entity.ToTable("Product55");
                // PK
                entity.HasKey(p => p.ProductId);
                // Index
                entity.HasIndex(p => p.Price).HasDatabaseName("index-product55-price");
                // FK
                entity.HasOne(p => p.Category55)
                .WithMany()
                .HasForeignKey("CateId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Foreign_Key_Product_Category");

                entity.HasOne(p => p.Category5502)
                .WithMany(c => c.Products)
                .HasForeignKey("CateId02")
                .OnDelete(DeleteBehavior.NoAction);
                // Name Table
                entity.Property(p => p.Name)
                .HasColumnName("Product Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(60)
                .IsRequired(false)
                .HasDefaultValue("Default product name");
            });
        }
    }
}