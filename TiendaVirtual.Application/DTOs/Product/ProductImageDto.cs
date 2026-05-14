namespace TiendaVirtual.Application.DTOs.Product;

public class ProductImageDto
{
    public int ProductImageId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? AltText { get; set; }
    public bool IsMain { get; set; }
    public int Order { get; set; }
}