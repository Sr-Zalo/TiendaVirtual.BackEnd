using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;
using TiendaVirtual.Infrastructure.Data;

namespace TiendaVirtual.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
            .Where(o => o.Enabled)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
            .Where(o => o.UserId == userId && o.Enabled)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
            .FirstOrDefaultAsync(o => o.OrderId == id && o.Enabled);
    }
}