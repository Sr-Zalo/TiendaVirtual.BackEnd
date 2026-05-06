namespace TiendaVirtual.Domain.Models;

public class ProductFilterParams
{
    public int? CategoryId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? MinPlayers { get; set; }
    public int? MaxPlayers { get; set; }
    public int? AvgDuration { get; set; }
    public int? MinAge { get; set; }
    public string? Type { get; set; }
    public string? Platform { get; set; }
    public int? Pegi { get; set; }
    public string? Language { get; set; }
    public string? Publisher { get; set; }
    public string? CollectibleType { get; set; }
    public bool? LimitedEdition { get; set; }
    public int? Pieces { get; set; }
    public string? Difficulty { get; set; }
    public string? SearchText { get; set; }
    public bool? OutOfStock { get; set; }
    public bool? NewArrivals { get; set; }
    public bool? BestSellers { get; set; }
}