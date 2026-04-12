using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Domain.Entities;

namespace TiendaVirtual.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<BoardGame> BoardGames { get; set; }
    public DbSet<VideoGame> VideoGames { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Collectible> Collectibles { get; set; }
    public DbSet<Puzzle> Puzzles { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role", "dbo");
            entity.HasKey(e => e.RoleId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", "dbo");
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Surname).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(500);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasOne(e => e.Role)
                  .WithMany(r => r.Users)
                  .HasForeignKey(e => e.RoleId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category", "dbo");
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", "dbo");
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Price).HasColumnType("decimal(10,2)");
            entity.HasOne(e => e.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(e => e.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<BoardGame>(entity =>
        {
            entity.ToTable("BoardGame", "dbo");
            entity.HasKey(e => e.BoardGameId);
            entity.HasOne(e => e.Product)
                  .WithOne(p => p.BoardGame)
                  .HasForeignKey<BoardGame>(e => e.BoardGameId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<VideoGame>(entity =>
        {
            entity.ToTable("VideoGame", "dbo");
            entity.HasKey(e => e.VideoGameId);
            entity.Property(e => e.Platform).HasMaxLength(100);
            entity.Property(e => e.Developer).HasMaxLength(150);
            entity.HasOne(e => e.Product)
                  .WithOne(p => p.VideoGame)
                  .HasForeignKey<VideoGame>(e => e.VideoGameId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book", "dbo");
            entity.HasKey(e => e.BookId);
            entity.Property(e => e.Author).HasMaxLength(150);
            entity.Property(e => e.Publisher).HasMaxLength(150);
            entity.Property(e => e.ISBN).HasMaxLength(20);
            entity.Property(e => e.Language).HasMaxLength(50);
            entity.HasOne(e => e.Product)
                  .WithOne(p => p.Book)
                  .HasForeignKey<Book>(e => e.BookId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Collectible>(entity =>
        {
            entity.ToTable("Collectible", "dbo");
            entity.HasKey(e => e.CollectibleId);
            entity.Property(e => e.Type).HasMaxLength(100);
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Size).HasMaxLength(100);
            entity.Property(e => e.Reference).HasMaxLength(200);
            entity.HasOne(e => e.Product)
                  .WithOne(p => p.Collectible)
                  .HasForeignKey<Collectible>(e => e.CollectibleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Puzzle>(entity =>
        {
            entity.ToTable("Puzzle", "dbo");
            entity.HasKey(e => e.PuzzleId);
            entity.Property(e => e.Difficulty).HasMaxLength(50);
            entity.Property(e => e.Shape).HasMaxLength(50);
            entity.Property(e => e.Material).HasMaxLength(100);
            entity.Property(e => e.Creator).HasMaxLength(150);
            entity.Property(e => e.Dimensions).HasMaxLength(100);
            entity.HasOne(e => e.Product)
                  .WithOne(p => p.Puzzle)
                  .HasForeignKey<Puzzle>(e => e.PuzzleId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.ToTable("ProductImage", "dbo");
            entity.HasKey(e => e.ProductImageId);
            entity.Property(e => e.Url).IsRequired().HasMaxLength(500);
            entity.Property(e => e.AltText).HasMaxLength(200);
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.Images)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart", "dbo");
            entity.HasKey(e => e.CartId);
            entity.HasOne(e => e.User)
                  .WithMany(u => u.CartItems)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.CartItems)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order", "dbo");
            entity.HasKey(e => e.OrderId);
            entity.Property(e => e.Total).HasColumnType("decimal(10,2)");
            entity.HasOne(e => e.User)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.ToTable("OrderLine", "dbo");
            entity.HasKey(e => e.OrderLineId);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,2)");
            entity.HasOne(e => e.Order)
                  .WithMany(o => o.OrderLines)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Product)
                  .WithMany(p => p.OrderLines)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}