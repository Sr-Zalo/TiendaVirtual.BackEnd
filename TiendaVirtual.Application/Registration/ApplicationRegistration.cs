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
        services.AddScoped<IBoardGameService, BoardGameService>();
        services.AddScoped<IVideoGameService, VideoGameService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICollectibleService, CollectibleService>();
        services.AddScoped<IPuzzleService, PuzzleService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}