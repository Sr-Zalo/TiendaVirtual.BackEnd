namespace TiendaVirtual.Domain.Entities;

public class Collectible : BaseEntity
{
    public int CollectibleId { get; set; }
    public string? Type { get; set; }
    public string? Material { get; set; }
    public bool LimitedEdition { get; set; } = false;
    public string? Size { get; set; }
    public string? Reference { get; set; }

    public Product Product { get; set; } = null!;
}