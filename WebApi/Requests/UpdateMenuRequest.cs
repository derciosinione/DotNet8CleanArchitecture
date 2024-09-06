namespace WebApi.Requests;

public record UpdateMenuRequest
{
    public required string Name { get; init; }
    public string? CodeI18N { get; init; }
}