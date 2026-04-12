using AutoMapper;
using TiendaVirtual.Application.DTOs.Order;
using TiendaVirtual.Application.Interfaces.Services;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Domain.Interfaces.Repositories;

namespace TiendaVirtual.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllWithDetailsAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<IEnumerable<OrderDto>> GetByUserIdAsync(int userId)
    {
        var orders = await _orderRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdWithDetailsAsync(id);
        return order is null ? null : _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateFromCartAsync(int userId)
    {
        var cartItems = await _cartRepository.GetByUserIdAsync(userId);
        var itemsList = cartItems.ToList();

        if (!itemsList.Any())
            throw new InvalidOperationException("El carrito está vacío");

        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            Status = 0,
            IUser = userId.ToString(),
            IDate = DateTime.UtcNow,
            OrderLines = itemsList.Select(item => new OrderLine
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.Product.Price,
                IUser = userId.ToString(),
                IDate = DateTime.UtcNow
            }).ToList()
        };

        order.Total = order.OrderLines.Sum(ol => ol.UnitPrice * ol.Quantity);

        await _orderRepository.AddAsync(order);
        await _cartRepository.ClearByUserIdAsync(userId);

        var created = await _orderRepository.GetByIdWithDetailsAsync(order.OrderId);
        return _mapper.Map<OrderDto>(created!);
    }
}