using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;

namespace TiendaVirtual.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoGameController : ControllerBase
{
    private readonly IVideoGameService _videoGameService;

    public VideoGameController(IVideoGameService videoGameService)
    {
        _videoGameService = videoGameService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVideoGameDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _videoGameService.AddAsync(dto, user);
        return Created();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateVideoGameDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _videoGameService.UpdateAsync(id, dto, user);
        return NoContent();
    }
}