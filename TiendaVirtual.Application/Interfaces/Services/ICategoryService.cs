using TiendaVirtual.Application.DTOs.Category;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
}