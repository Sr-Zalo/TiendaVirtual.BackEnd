namespace TiendaVirtual.Domain.Entities;

public class BoardGame : BaseEntity
{
    public int BoardGameId { get; set; }
    public int? MinPlayers { get; set; }
    public int? MaxPlayers { get; set; }
    public int? AvgDuration { get; set; }
    public int? MinAge { get; set; }
    public string? Type { get; set; }

    public Product Product { get; set; } = null!;
}