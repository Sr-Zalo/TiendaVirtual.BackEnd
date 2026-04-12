namespace TiendaVirtual.Application.DTOs.Order;

public class OrderDto
{
    public int OrderId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public byte Status { get; set; }
    public decimal Total { get; set; }
    public List<OrderLineDto> Lines { get; set; } = new();
}