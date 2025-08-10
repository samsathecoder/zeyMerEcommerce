using Microsoft.EntityFrameworkCore;

using ZeyMer.Domain.Entities;

namespace ZeyMer.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tablo isimlerini tekil yapalım
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<CartItem>().ToTable("CartItem");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Category>().ToTable("Category");

            // İlişkiler
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Product)
                .WithMany() // Eğer Product içinde CartItems koleksiyonu varsa oraya bağla
                .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.User)
                .WithMany() // Eğer User içinde CartItems koleksiyonu varsa oraya bağla
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany() // Eğer User içinde Orders koleksiyonu varsa oraya bağla
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)           // Her ürünün bir kategorisi vardır
                .WithMany(c => c.Products)         // Bir kategorinin birden fazla ürünü olabilir
                .HasForeignKey(p => p.CategoryId);

            // Decimal alanlara otomatik precision ve scale atama
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }
    }
}