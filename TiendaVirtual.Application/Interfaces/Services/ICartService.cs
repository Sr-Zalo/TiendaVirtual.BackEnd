using TiendaVirtual.Application.DTOs.Cart;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface ICartService
{
    Task<IEnumerable<CartItemDto>> GetByUserIdAsync(int userId);
    Task AddOrUpdateAsync(int userId, AddToCartDto dto);
    Task RemoveAsync(int userId, int cartId);
    Task ClearAsync(int userId);
    Task UpdateQuantityAsync(int userId, int cartId, int quantity);
}