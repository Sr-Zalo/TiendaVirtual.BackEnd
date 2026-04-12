namespace TiendaVirtual.Application.DTOs.Product;

public class CreateVideoGameDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Platform { get; set; }
    public string? Developer { get; set; }
    public int? Pegi { get; set; }
}