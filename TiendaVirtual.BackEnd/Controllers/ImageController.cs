using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Infrastructure.Data;

namespace TiendaVirtual.BackEnd.Controllers;

[ApiController]
[Route("api/image")]
[Authorize]
public class ImageController : ControllerBase
{
    private readonly AppDbContext _context;

    public ImageController(AppDbContext context)
    {
        _context = context;
    }

    // POST /api/image/{productId}
    [HttpPost("{productId}")]
    public async Task<IActionResult> AddImage(int productId, [FromBody] AddImageDto dto)
    {
        var product = await _context.Products
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.ProductId == productId && p.Enabled);

        if (product == null)
            return NotFound("Producto no encontrado");

        if (product.Images.Count >= 4)
            return BadRequest("El producto ya tiene el máximo de 4 imágenes");

        // Si es la primera imagen o se marca como principal, quitar el principal anterior
        if (dto.IsMain || !product.Images.Any())
        {
            foreach (var existing in product.Images)
                existing.IsMain = false;
        }

        var image = new ProductImage
        {
            ProductId = productId,
            Url = dto.Url,
            AltText = dto.AltText,
            IsMain = dto.IsMain || !product.Images.Any(),
            Order = product.Images.Count,
            Enabled = true,
            IDate = DateTime.Now
        };

        _context.ProductImages.Add(image);
        await _context.SaveChangesAsync();

        return Ok(new ProductImageDto
        {
            ProductImageId = image.ProductImageId,
            Url = image.Url,
            AltText = image.AltText,
            IsMain = image.IsMain,
            Order = image.Order
        });
    }

    // DELETE /api/image/{imageId}
    [HttpDelete("{imageId}")]
    public async Task<IActionResult> DeleteImage(int imageId)
    {
        var image = await _context.ProductImages
            .FirstOrDefaultAsync(i => i.ProductImageId == imageId);

        if (image == null)
            return NotFound("Imagen no encontrada");

        bool wasMain = image.IsMain;
        int productId = image.ProductId;

        _context.ProductImages.Remove(image);
        await _context.SaveChangesAsync();

        // Si era la principal, asignar la primera restante como principal
        if (wasMain)
        {
            var first = await _context.ProductImages
                .Where(i => i.ProductId == productId)
                .OrderBy(i => i.Order)
                .FirstOrDefaultAsync();

            if (first != null)
            {
                first.IsMain = true;
                await _context.SaveChangesAsync();
            }
        }

        return NoContent();
    }

    // PUT /api/image/{imageId}/main
    [HttpPut("{imageId}/main")]
    public async Task<IActionResult> SetMain(int imageId)
    {
        var image = await _context.ProductImages.FindAsync(imageId);
        if (image == null) return NotFound();

        var allImages = await _context.ProductImages
            .Where(i => i.ProductId == image.ProductId)
            .ToListAsync();

        foreach (var img in allImages)
            img.IsMain = false;

        image.IsMain = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}