using AutoMapper;
using TiendaVirtual.Application.DTOs.Cart;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CartService(
        ICartRepository cartRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CartItemDto>> GetByUserIdAsync(int userId)
    {
        var items = await _cartRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<CartItemDto>>(items);
    }

    public async Task AddOrUpdateAsync(int userId, AddToCartDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.ProductId);
        if (product is null)
            throw new InvalidOperationException("Producto no encontrado");

        var existing = await _cartRepository.GetByUserAndProductAsync(userId, dto.ProductId);
        var currentQty = existing?.Quantity ?? 0;
        var newQty = currentQty + dto.Quantity;

        if (newQty > product.Stock)
            throw new InvalidOperationException(
                $"No hay suficiente stock. Stock disponible: {product.Stock}");

        if (existing is not null)
        {
            existing.Quantity = newQty;
            await _cartRepository.UpdateAsync(existing);
        }
        else
        {
            var cart = new Cart
            {
                UserId = userId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                IUser = userId.ToString(),
                IDate = DateTime.UtcNow
            };
            await _cartRepository.AddAsync(cart);
        }
    }

    public async Task RemoveAsync(int userId, int cartId)
    {
        await _cartRepository.DeleteAsync(cartId);
    }

    public async Task ClearAsync(int userId)
    {
        await _cartRepository.ClearByUserIdAsync(userId);
    }

    public async Task UpdateQuantityAsync(int userId, int cartId, int quantity)
    {
        if (quantity <= 0)
        {
            await _cartRepository.DeleteAsync(cartId);
            return;
        }
        await _cartRepository.UpdateQuantityAsync(cartId, quantity);
    }


}