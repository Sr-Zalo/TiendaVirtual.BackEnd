using AutoMapper;
using TiendaVirtual.Application.DTOs.Cart;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartService(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CartItemDto>> GetByUserIdAsync(int userId)
    {
        var items = await _cartRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<CartItemDto>>(items);
    }

    public async Task AddOrUpdateAsync(int userId, AddToCartDto dto)
    {
        var existing = await _cartRepository.GetByUserAndProductAsync(userId, dto.ProductId);

        if (existing is not null)
        {
            existing.Quantity += dto.Quantity;
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
}