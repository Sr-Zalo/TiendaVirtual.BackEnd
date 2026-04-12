using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class CollectibleService : ICollectibleService
{
    private readonly IProductRepository _productRepository;

    public CollectibleService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddAsync(CreateCollectibleDto dto, string iUser)
    {
        var product = new Product
        {
            CategoryId = dto.CategoryId,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            IUser = iUser,
            IDate = DateTime.UtcNow,
            Collectible = new Collectible
            {
                Type = dto.Type,
                Material = dto.Material,
                LimitedEdition = dto.LimitedEdition,
                Size = dto.Size,
                Reference = dto.Reference,
                IUser = iUser,
                IDate = DateTime.UtcNow
            }
        };

        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(int id, UpdateCollectibleDto dto, string uUser)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null) return;

        product.CategoryId = dto.CategoryId;
        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.UUser = uUser;
        product.UDate = DateTime.UtcNow;

        if (product.Collectible is not null)
        {
            product.Collectible.Type = dto.Type;
            product.Collectible.Material = dto.Material;
            product.Collectible.LimitedEdition = dto.LimitedEdition;
            product.Collectible.Size = dto.Size;
            product.Collectible.Reference = dto.Reference;
            product.Collectible.UUser = uUser;
            product.Collectible.UDate = DateTime.UtcNow;
        }

        await _productRepository.UpdateAsync(product);
    }
}