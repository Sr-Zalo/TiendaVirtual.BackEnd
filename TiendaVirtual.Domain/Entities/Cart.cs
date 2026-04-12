namespace TiendaVirtual.Domain.Entities;

public class Cart : BaseEntity
{
    public int CartId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 1;

    public User User { get; set; } = null!;
    public Product Product { get; set; } = null!;
}