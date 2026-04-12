using AutoMapper;
using TiendaVirtual.Application.DTOs.Category;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<TiendaVirtual.Domain.Entities.Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(
        IGenericRepository<TiendaVirtual.Domain.Entities.Category> categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
}