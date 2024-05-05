namespace TodoApi.Models;

public record TodoDetailsDto
{
    public long Id { get; set; }
    public int? Row { get; set; }
    public int? Factorial { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
}
