using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS57
{
    public class WebContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }


        public const string connectionString = @"
            Data Source=.\SQLEXPRESS;
            Initial Catalog=webdb57; 
            User ID=sa; 
            Password=1234;
            Encrypt = false";

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
            .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
            .AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasIndex(articleTag => new {articleTag.ArticleId, articleTag.TagId}).IsUnique();
            });
        }
    }
}