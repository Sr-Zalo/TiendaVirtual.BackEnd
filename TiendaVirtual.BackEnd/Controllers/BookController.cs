using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.Interfaces.Services;

namespace TiendaVirtual.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _bookService.AddAsync(dto, user);
        return Created();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookDto dto)
    {
        var user = User.Identity?.Name ?? "system";
        await _bookService.UpdateAsync(id, dto, user);
        return NoContent();
    }
}