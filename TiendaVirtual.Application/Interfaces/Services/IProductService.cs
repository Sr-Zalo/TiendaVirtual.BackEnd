using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Domain.Models;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync(bool includeOutOfStock = false);
    Task<ProductDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId);
    Task<IEnumerable<ProductDto>> GetFilteredAsync(ProductFilterParams filters, bool includeOutOfStock = false);
    Task AddAsync(CreateProductDto dto, string iUser);
    Task UpdateAsync(int id, UpdateProductDto dto, string uUser);
    Task DeleteAsync(int id);
}