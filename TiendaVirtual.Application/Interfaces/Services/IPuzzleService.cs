using TiendaVirtual.Application.DTOs.Product;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IPuzzleService
{
    Task AddAsync(CreatePuzzleDto dto, string iUser);
    Task UpdateAsync(int id, UpdatePuzzleDto dto, string uUser);
}