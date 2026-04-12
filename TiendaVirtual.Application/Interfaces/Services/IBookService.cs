using TiendaVirtual.Application.DTOs.Product;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IBookService
{
    Task AddAsync(CreateBookDto dto, string iUser);
    Task UpdateAsync(int id, UpdateBookDto dto, string uUser);
}