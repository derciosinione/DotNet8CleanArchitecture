namespace Application.Menus.Responses;

public class MenuResponse
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? CodeI18N { get; set; }
    public int Level { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}