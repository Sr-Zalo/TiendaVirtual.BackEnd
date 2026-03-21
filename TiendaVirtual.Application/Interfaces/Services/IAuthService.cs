using TiendaVirtual.Application.DTOs.Auth;

namespace TiendaVirtual.Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponseDto?> LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);
}