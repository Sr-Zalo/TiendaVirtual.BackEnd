using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;

namespace TiendaVirtual.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollectibleController : ControllerBase
{
    private readonly ICollectibleService _collectibleService;

    public CollectibleController(ICollectibleService collectibleService)
    {
        _collectibleService = collectibleService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCollectibleDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _collectibleService.AddAsync(dto, user);
        return Created();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCollectibleDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _collectibleService.UpdateAsync(id, dto, user);
        return NoContent();
    }
}