namespace TiendaVirtual.Domain.Entities;

public abstract class BaseEntity
{
    public bool Enabled { get; set; } = true;
    public string? IUser { get; set; }
    public DateTime? IDate { get; set; }
    public string? UUser { get; set; }
    public DateTime? UDate { get; set; }
    public string? IComments { get; set; }
    public string? UComments { get; set; }
}