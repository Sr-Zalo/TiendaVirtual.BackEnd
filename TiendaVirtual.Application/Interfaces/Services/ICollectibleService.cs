using TiendaVirtual.Application.DTOs.Product;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface ICollectibleService
{
    Task AddAsync(CreateCollectibleDto dto, string iUser);
    Task UpdateAsync(int id, UpdateCollectibleDto dto, string uUser);
}