namespace TiendaVirtual.Application.DTOs.Product;

public class BoardGameDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int? MinPlayers { get; set; }
    public int? MaxPlayers { get; set; }
    public int? AvgDuration { get; set; }
    public int? MinAge { get; set; }
    public string? Type { get; set; }
}