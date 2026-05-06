using TiendaVirtual.Domain.Entities;

namespace TiendaVirtual.Domain.Interfaces.Repositories;

public interface ICartRepository : IGenericRepository<Cart>
{
    Task<IEnumerable<Cart>> GetByUserIdAsync(int userId);
    Task<Cart?> GetByUserAndProductAsync(int userId, int productId);
    Task ClearByUserIdAsync(int userId);
    Task UpdateQuantityAsync(int cartId, int quantity);
}