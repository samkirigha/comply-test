using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos;

public record AddTodoDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
}
