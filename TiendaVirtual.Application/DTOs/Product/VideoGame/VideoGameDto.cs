namespace TiendaVirtual.Application.DTOs.Product;

public class VideoGameDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Platform { get; set; }
    public string? Developer { get; set; }
    public int? Pegi { get; set; }
}