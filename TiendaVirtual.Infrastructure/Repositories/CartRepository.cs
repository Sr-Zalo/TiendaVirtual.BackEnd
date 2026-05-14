using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;
using TiendaVirtual.Infrastructure.Data;

namespace TiendaVirtual.Infrastructure.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Cart>> GetByUserIdAsync(int userId)
    {
        return await _context.Carts
            .Include(c => c.Product)
            .ThenInclude(p => p.Images)
            .Where(c => c.UserId == userId && c.Enabled)
            .ToListAsync();
    }

    public async Task<Cart?> GetByUserAndProductAsync(int userId, int productId)
    {
        return await _context.Carts
            .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId && c.Enabled);
    }

    public async Task ClearByUserIdAsync(int userId)
    {
        var items = await _context.Carts
            .Where(c => c.UserId == userId && c.Enabled)
            .ToListAsync();
        foreach (var item in items)
            item.Enabled = false;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateQuantityAsync(int cartId, int quantity)
    {
        var cart = await _context.Carts.FindAsync(cartId);
        if (cart is not null)
        {
            cart.Quantity = quantity;
            await _context.SaveChangesAsync();
        }
    }
}