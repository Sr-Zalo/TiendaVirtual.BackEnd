using TiendaVirtual.Domain.Entities;

namespace TiendaVirtual.Domain.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}