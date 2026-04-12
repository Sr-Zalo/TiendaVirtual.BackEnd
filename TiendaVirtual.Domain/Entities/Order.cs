namespace TiendaVirtual.Domain.Entities;

public class Order : BaseEntity
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public byte Status { get; set; } = 0;
    public decimal Total { get; set; }

    public User User { get; set; } = null!;
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}