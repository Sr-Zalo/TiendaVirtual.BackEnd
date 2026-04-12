using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;

namespace TiendaVirtual.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PuzzleController : ControllerBase
{
    private readonly IPuzzleService _puzzleService;

    public PuzzleController(IPuzzleService puzzleService)
    {
        _puzzleService = puzzleService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePuzzleDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _puzzleService.AddAsync(dto, user);
        return Created();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePuzzleDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _puzzleService.UpdateAsync(id, dto, user);
        return NoContent();
    }
}