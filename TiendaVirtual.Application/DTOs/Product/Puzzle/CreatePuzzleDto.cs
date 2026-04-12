namespace TiendaVirtual.Application.DTOs.Product;

public class CreatePuzzleDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int? Pieces { get; set; }
    public string? Difficulty { get; set; }
    public string? Shape { get; set; }
    public string? Material { get; set; }
    public int? MinAge { get; set; }
    public string? Creator { get; set; }
    public string? Dimensions { get; set; }
}