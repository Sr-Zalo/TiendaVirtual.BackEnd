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
}