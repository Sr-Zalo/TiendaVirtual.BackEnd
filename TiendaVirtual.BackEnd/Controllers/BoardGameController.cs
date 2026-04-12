using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;

namespace TiendaVirtual.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardGameController : ControllerBase
{
    private readonly IBoardGameService _boardGameService;

    public BoardGameController(IBoardGameService boardGameService)
    {
        _boardGameService = boardGameService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBoardGameDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _boardGameService.AddAsync(dto, user);
        return Created();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBoardGameDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _boardGameService.UpdateAsync(id, dto, user);
        return NoContent();
    }
}