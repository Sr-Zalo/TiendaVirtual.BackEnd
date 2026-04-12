using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class PuzzleService : IPuzzleService
{
    private readonly IProductRepository _productRepository;

    public PuzzleService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddAsync(CreatePuzzleDto dto, string iUser)
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
            Puzzle = new Puzzle
            {
                Pieces = dto.Pieces,
                Difficulty = dto.Difficulty,
                Shape = dto.Shape,
                Material = dto.Material,
                MinAge = dto.MinAge,
                Creator = dto.Creator,
                Dimensions = dto.Dimensions,
                IUser = iUser,
                IDate = DateTime.UtcNow
            }
        };

        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(int id, UpdatePuzzleDto dto, string uUser)
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

        if (product.Puzzle is not null)
        {
            product.Puzzle.Pieces = dto.Pieces;
            product.Puzzle.Difficulty = dto.Difficulty;
            product.Puzzle.Shape = dto.Shape;
            product.Puzzle.Material = dto.Material;
            product.Puzzle.MinAge = dto.MinAge;
            product.Puzzle.Creator = dto.Creator;
            product.Puzzle.Dimensions = dto.Dimensions;
            product.Puzzle.UUser = uUser;
            product.Puzzle.UDate = DateTime.UtcNow;
        }

        await _productRepository.UpdateAsync(product);
    }
}