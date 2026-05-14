namespace TiendaVirtual.Application.DTOs.Product;

public class AddImageDto
{
    public string Url { get; set; } = string.Empty;
    public string? AltText { get; set; }
    public bool IsMain { get; set; }
}