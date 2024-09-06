namespace WebApi.Requests;

public record CreateMenuRequest
{
    public required string Name { get; init; }
    public string? CodeI18N { get; init; }
}