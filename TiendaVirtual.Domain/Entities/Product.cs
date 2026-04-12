namespace TiendaVirtual.Domain.Entities;

public class Product : BaseEntity
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Category Category { get; set; } = null!;
    public BoardGame? BoardGame { get; set; }
    public VideoGame? VideoGame { get; set; }
    public Book? Book { get; set; }
    public Collectible? Collectible { get; set; }
    public Puzzle? Puzzle { get; set; }
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<Cart> CartItems { get; set; } = new List<Cart>();
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}