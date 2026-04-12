using AutoMapper;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class BoardGameService : IBoardGameService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public BoardGameService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(CreateBoardGameDto dto, string iUser)
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
            BoardGame = new BoardGame
            {
                MinPlayers = dto.MinPlayers,
                MaxPlayers = dto.MaxPlayers,
                AvgDuration = dto.AvgDuration,
                MinAge = dto.MinAge,
                Type = dto.Type,
                IUser = iUser,
                IDate = DateTime.UtcNow
            }
        };

        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(int id, UpdateBoardGameDto dto, string uUser)
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

        if (product.BoardGame is not null)
        {
            product.BoardGame.MinPlayers = dto.MinPlayers;
            product.BoardGame.MaxPlayers = dto.MaxPlayers;
            product.BoardGame.AvgDuration = dto.AvgDuration;
            product.BoardGame.MinAge = dto.MinAge;
            product.BoardGame.Type = dto.Type;
            product.BoardGame.UUser = uUser;
            product.BoardGame.UDate = DateTime.UtcNow;
        }

        await _productRepository.UpdateAsync(product);
    }
}