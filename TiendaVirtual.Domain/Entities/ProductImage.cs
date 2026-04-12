namespace TiendaVirtual.Domain.Entities;

public class ProductImage : BaseEntity
{
    public int ProductImageId { get; set; }
    public int ProductId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? AltText { get; set; }
    public bool IsMain { get; set; } = false;
    public int Order { get; set; } = 0;

    public Product Product { get; set; } = null!;
}