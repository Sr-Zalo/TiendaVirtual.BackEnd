using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TiendaVirtual.Application.DTOs.Cart;
using TiendaVirtual.Application.Interfaces.Services;

namespace TiendaVirtual.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyCart()
    {
        var userId = GetUserId();
        if (userId is null) return Unauthorized();
        var items = await _cartService.GetByUserIdAsync(userId.Value);
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
    {
        var userId = GetUserId();
        if (userId is null) return Unauthorized();
        await _cartService.AddOrUpdateAsync(userId.Value, dto);
        return Ok();
    }

    [HttpDelete("{cartId}")]
    public async Task<IActionResult> RemoveItem(int cartId)
    {
        var userId = GetUserId();
        if (userId is null) return Unauthorized();
        await _cartService.RemoveAsync(userId.Value, cartId);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> ClearCart()
    {
        var userId = GetUserId();
        if (userId is null) return Unauthorized();
        await _cartService.ClearAsync(userId.Value);
        return NoContent();
    }

    private int? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return claim is not null ? int.Parse(claim) : null;
    }
}