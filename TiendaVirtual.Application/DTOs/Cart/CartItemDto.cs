namespace TiendaVirtual.Application.DTOs.Cart;

public class CartItemDto
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal => Price * Quantity;
    public string? ImageUrl { get; set; }
}