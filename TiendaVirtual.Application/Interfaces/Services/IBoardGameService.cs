using TiendaVirtual.Application.DTOs.Product;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IBoardGameService
{
    Task AddAsync(CreateBoardGameDto dto, string iUser);
    Task UpdateAsync(int id, UpdateBoardGameDto dto, string uUser);
}