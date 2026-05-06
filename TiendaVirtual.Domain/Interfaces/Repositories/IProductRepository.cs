using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Models;

namespace TiendaVirtual.Domain.Interfaces.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllAsync(bool includeOutOfStock);
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetFilteredAsync(ProductFilterParams filters, bool includeOutOfStock = false);
}