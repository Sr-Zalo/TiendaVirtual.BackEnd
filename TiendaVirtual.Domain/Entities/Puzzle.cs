namespace TiendaVirtual.Domain.Entities;

public class Puzzle : BaseEntity
{
    public int PuzzleId { get; set; }
    public int? Pieces { get; set; }
    public string? Difficulty { get; set; }
    public string? Shape { get; set; }
    public string? Material { get; set; }
    public int? MinAge { get; set; }
    public string? Creator { get; set; }
    public string? Dimensions { get; set; }

    public Product Product { get; set; } = null!;
}