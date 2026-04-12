using TiendaVirtual.Application.DTOs.Order;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<IEnumerable<OrderDto>> GetByUserIdAsync(int userId);
    Task<OrderDto?> GetByIdAsync(int id);
    Task<OrderDto> CreateFromCartAsync(int userId);
}