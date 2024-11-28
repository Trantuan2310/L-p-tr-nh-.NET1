using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS54
{
    public class ShopContext54 : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<Product54> products { get; set; }
        public DbSet<Category54> categorys { get; set; }

        private const string connectionString = @"
            Data Source=.\SQLEXPRESS;
            Initial Catalog=shopdata54; 
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product54>(entity =>
            {
                // Table mapping
                entity.ToTable("Product54");
                // PK
                entity.HasKey(p => p.ProductId);
                // Index
                entity.HasIndex(p => p.Price).HasDatabaseName("index-product54-price");
                // FK
                entity.HasOne(p => p.Category54)
                .WithMany()
                .HasForeignKey("CateId")
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Khoa_ngoai_Sanpham_Category");

                entity.HasOne(p => p.Category5402)
                .WithMany(c => c.Products)
                .HasForeignKey("CateId02")
                .OnDelete(DeleteBehavior.NoAction);
                // Name Table
                entity.Property(p => p.Name)
                .HasColumnName("title")
                .HasColumnType("nvarchar")
                .HasMaxLength(60)
                .IsRequired(false)
                .HasDefaultValue("Ten san pham mac dinh");
            });
        }
    }
}