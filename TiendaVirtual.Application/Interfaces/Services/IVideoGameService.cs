using TiendaVirtual.Application.DTOs.Product;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IVideoGameService
{
    Task AddAsync(CreateVideoGameDto dto, string iUser);
    Task UpdateAsync(int id, UpdateVideoGameDto dto, string uUser);
}