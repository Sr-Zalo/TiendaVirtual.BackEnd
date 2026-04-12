using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class VideoGameService : IVideoGameService
{
    private readonly IProductRepository _productRepository;

    public VideoGameService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddAsync(CreateVideoGameDto dto, string iUser)
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
            VideoGame = new VideoGame
            {
                Platform = dto.Platform,
                Developer = dto.Developer,
                Pegi = dto.Pegi,
                IUser = iUser,
                IDate = DateTime.UtcNow
            }
        };

        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(int id, UpdateVideoGameDto dto, string uUser)
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

        if (product.VideoGame is not null)
        {
            product.VideoGame.Platform = dto.Platform;
            product.VideoGame.Developer = dto.Developer;
            product.VideoGame.Pegi = dto.Pegi;
            product.VideoGame.UUser = uUser;
            product.VideoGame.UDate = DateTime.UtcNow;
        }

        await _productRepository.UpdateAsync(product);
    }
}