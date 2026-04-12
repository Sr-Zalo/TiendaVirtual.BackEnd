namespace TiendaVirtual.Application.DTOs.Product;

public class CreateCollectibleDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Type { get; set; }
    public string? Material { get; set; }
    public bool LimitedEdition { get; set; }
    public string? Size { get; set; }
    public string? Reference { get; set; }
}