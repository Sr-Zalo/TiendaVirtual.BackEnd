namespace TiendaVirtual.Domain.Entities;

public class VideoGame : BaseEntity
{
    public int VideoGameId { get; set; }
    public string? Platform { get; set; }
    public string? Developer { get; set; }
    public int? Pegi { get; set; }

    public Product Product { get; set; } = null!;
}