using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;
using TiendaVirtual.Infrastructure.Data;

namespace TiendaVirtual.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public override async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.BoardGame)
            .FirstOrDefaultAsync(p => p.ProductId == id && p.Enabled);
    }

    public override async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.BoardGame)
            .Where(p => p.Enabled)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.BoardGame)
            .Where(p => p.CategoryId == categoryId && p.Enabled)
            .ToListAsync();
    }
}