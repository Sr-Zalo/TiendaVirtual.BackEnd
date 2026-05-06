namespace TiendaVirtual.Application.DTOs.Product;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    // BoardGame
    public int? MinPlayers { get; set; }
    public int? MaxPlayers { get; set; }
    public int? AvgDuration { get; set; }
    public int? MinAge { get; set; }
    public string? BoardGameType { get; set; }

    // VideoGame
    public string? Platform { get; set; }
    public string? Developer { get; set; }
    public int? Pegi { get; set; }

    // Book
    public string? Author { get; set; }
    public string? Publisher { get; set; }
    public string? ISBN { get; set; }
    public int? Pages { get; set; }
    public string? Language { get; set; }

    // Collectible
    public string? CollectibleType { get; set; }
    public string? Material { get; set; }
    public bool? LimitedEdition { get; set; }
    public string? Size { get; set; }
    public string? Reference { get; set; }

    // Puzzle
    public int? Pieces { get; set; }
    public string? Difficulty { get; set; }
    public string? Shape { get; set; }
    public string? Creator { get; set; }
    public string? Dimensions { get; set; }

    public int CategoryId { get; set; }
}