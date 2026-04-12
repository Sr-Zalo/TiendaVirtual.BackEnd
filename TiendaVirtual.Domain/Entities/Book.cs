namespace TiendaVirtual.Domain.Entities;

public class Book : BaseEntity
{
    public int BookId { get; set; }
    public string? Author { get; set; }
    public string? Publisher { get; set; }
    public string? ISBN { get; set; }
    public int? Pages { get; set; }
    public string? Language { get; set; }

    public Product Product { get; set; } = null!;
}