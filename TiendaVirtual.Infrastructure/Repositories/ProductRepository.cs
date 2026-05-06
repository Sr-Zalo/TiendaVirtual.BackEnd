using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;
using TiendaVirtual.Domain.Models;
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
            .Include(p => p.VideoGame)
            .Include(p => p.Book)
            .Include(p => p.Collectible)
            .Include(p => p.Puzzle)
            .FirstOrDefaultAsync(p => p.ProductId == id && p.Enabled);
    }

    public override async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.BoardGame)
            .Include(p => p.VideoGame)
            .Include(p => p.Book)
            .Include(p => p.Collectible)
            .Include(p => p.Puzzle)
            .Where(p => p.Enabled)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.BoardGame)
            .Include(p => p.VideoGame)
            .Include(p => p.Book)
            .Include(p => p.Collectible)
            .Include(p => p.Puzzle)
            .Where(p => p.CategoryId == categoryId && p.Enabled)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync(bool includeOutOfStock)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.BoardGame)
            .Include(p => p.VideoGame)
            .Include(p => p.Book)
            .Include(p => p.Collectible)
            .Include(p => p.Puzzle)
            .Where(p => p.Enabled);

        if (!includeOutOfStock)
            query = query.Where(p => p.Stock > 0);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetFilteredAsync(ProductFilterParams filters, bool includeOutOfStock = false)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.BoardGame)
            .Include(p => p.VideoGame)
            .Include(p => p.Book)
            .Include(p => p.Collectible)
            .Include(p => p.Puzzle)
            .Include(p => p.OrderLines)
            .Where(p => p.Enabled);

        if (!includeOutOfStock)
            query = query.Where(p => p.Stock > 0);

        if (filters.CategoryId.HasValue)
            query = query.Where(p => p.CategoryId == filters.CategoryId);
        if (filters.MinPrice.HasValue)
            query = query.Where(p => p.Price >= filters.MinPrice);
        if (filters.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= filters.MaxPrice);
        if (filters.MinPlayers.HasValue)
            query = query.Where(p => p.BoardGame != null && p.BoardGame.MinPlayers <= filters.MinPlayers);
        if (filters.MaxPlayers.HasValue)
            query = query.Where(p => p.BoardGame != null && p.BoardGame.MaxPlayers >= filters.MaxPlayers);
        if (filters.AvgDuration.HasValue)
            query = query.Where(p => p.BoardGame != null && p.BoardGame.AvgDuration <= filters.AvgDuration);
        if (filters.MinAge.HasValue)
            query = query.Where(p =>
                (p.BoardGame != null && p.BoardGame.MinAge <= filters.MinAge) ||
                (p.Puzzle != null && p.Puzzle.MinAge <= filters.MinAge));
        if (!string.IsNullOrEmpty(filters.Type))
            query = query.Where(p => p.BoardGame != null && p.BoardGame.Type == filters.Type);
        if (!string.IsNullOrEmpty(filters.Platform))
            query = query.Where(p => p.VideoGame != null && p.VideoGame.Platform == filters.Platform);
        if (filters.Pegi.HasValue)
            query = query.Where(p => p.VideoGame != null && p.VideoGame.Pegi <= filters.Pegi);
        if (!string.IsNullOrEmpty(filters.Language))
            query = query.Where(p => p.Book != null && p.Book.Language == filters.Language);
        if (!string.IsNullOrEmpty(filters.Publisher))
            query = query.Where(p => p.Book != null && p.Book.Publisher == filters.Publisher);
        if (!string.IsNullOrEmpty(filters.CollectibleType))
            query = query.Where(p => p.Collectible != null && p.Collectible.Type == filters.CollectibleType);
        if (filters.LimitedEdition.HasValue)
            query = query.Where(p => p.Collectible != null && p.Collectible.LimitedEdition == filters.LimitedEdition);
        if (filters.Pieces.HasValue)
            query = query.Where(p => p.Puzzle != null && p.Puzzle.Pieces <= filters.Pieces);
        if (!string.IsNullOrEmpty(filters.Difficulty))
            query = query.Where(p => p.Puzzle != null && p.Puzzle.Difficulty == filters.Difficulty);
        if (!string.IsNullOrEmpty(filters.SearchText))
            query = query.Where(p => p.Name.Contains(filters.SearchText) ||
                                     (p.Description != null && p.Description.Contains(filters.SearchText)));
        if (filters.OutOfStock.HasValue && filters.OutOfStock.Value)
            query = query.Where(p => p.Stock == 0);

        if (filters.NewArrivals.HasValue && filters.NewArrivals.Value)
            query = query.OrderByDescending(p => p.IDate);

        if (filters.BestSellers.HasValue && filters.BestSellers.Value)
            query = query.OrderByDescending(p =>
                p.OrderLines.Sum(ol => ol.Quantity));
        if (!includeOutOfStock && !(filters.OutOfStock.HasValue && filters.OutOfStock.Value))
            query = query.Where(p => p.Stock > 0);

        return await query.ToListAsync();
    }

    public override async Task UpdateAsync(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;

        if (product.BoardGame is not null)
            _context.Entry(product.BoardGame).State = EntityState.Modified;

        if (product.VideoGame is not null)
            _context.Entry(product.VideoGame).State = EntityState.Modified;

        if (product.Book is not null)
            _context.Entry(product.Book).State = EntityState.Modified;

        if (product.Collectible is not null)
            _context.Entry(product.Collectible).State = EntityState.Modified;

        if (product.Puzzle is not null)
            _context.Entry(product.Puzzle).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}