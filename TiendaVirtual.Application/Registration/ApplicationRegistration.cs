using Microsoft.Extensions.DependencyInjection;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Application.Services;

namespace TiendaVirtual.Application.Registration;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationRegistration).Assembly);

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}