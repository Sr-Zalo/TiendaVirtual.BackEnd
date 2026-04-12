using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class BookService : IBookService
{
    private readonly IProductRepository _productRepository;

    public BookService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddAsync(CreateBookDto dto, string iUser)
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
            Book = new Book
            {
                Author = dto.Author,
                Publisher = dto.Publisher,
                ISBN = dto.ISBN,
                Pages = dto.Pages,
                Language = dto.Language,
                IUser = iUser,
                IDate = DateTime.UtcNow
            }
        };

        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(int id, UpdateBookDto dto, string uUser)
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

        if (product.Book is not null)
        {
            product.Book.Author = dto.Author;
            product.Book.Publisher = dto.Publisher;
            product.Book.ISBN = dto.ISBN;
            product.Book.Pages = dto.Pages;
            product.Book.Language = dto.Language;
            product.Book.UUser = uUser;
            product.Book.UDate = DateTime.UtcNow;
        }

        await _productRepository.UpdateAsync(product);
    }
}