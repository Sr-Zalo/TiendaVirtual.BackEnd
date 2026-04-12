namespace TiendaVirtual.Application.DTOs.Product;

public class CreateBookDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Author { get; set; }
    public string? Publisher { get; set; }
    public string? ISBN { get; set; }
    public int? Pages { get; set; }
    public string? Language { get; set; }
}