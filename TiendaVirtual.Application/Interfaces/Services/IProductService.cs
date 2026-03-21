using TiendaVirtual.Application.DTOs.Product;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId);
    Task AddAsync(CreateProductDto dto, string iUser);
    Task UpdateAsync(int id, UpdateProductDto dto, string uUser);
    Task DeleteAsync(int id);
}