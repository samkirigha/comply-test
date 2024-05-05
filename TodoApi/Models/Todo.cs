namespace TodoApi.Models;

public class Todo
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public virtual byte[]? RowVersion { get; set; }
}
