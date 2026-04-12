using TiendaVirtual.Domain.Entities;

namespace TiendaVirtual.Domain.Interfaces.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
}