using AutoMapper;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product is null ? null : _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId)
    {
        var products = await _productRepository.GetByCategoryAsync(categoryId);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task AddAsync(CreateProductDto dto, string iUser)
    {
        var product = _mapper.Map<Product>(dto);
        product.IUser = iUser;
        product.IDate = DateTime.UtcNow;
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(int id, UpdateProductDto dto, string uUser)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null) return;

        _mapper.Map(dto, product);
        product.UUser = uUser;
        product.UDate = DateTime.UtcNow;
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}