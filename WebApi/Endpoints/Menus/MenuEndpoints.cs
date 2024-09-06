using WebApi.Abstractions;
using WebApi.Endpoints.Menus.Utils;

namespace WebApi.Endpoints.Menus;

public class MenuEndpoints : IEndpointDefinitions
{
    private const string BaseEndpoint = "/api/menu";

    public void RegisterEndpoints(WebApplication app)
    {
        var api = app.MapGroup(BaseEndpoint);

        api.MapGet(string.Empty, GetAllMenus.Execute)
            .WithName(nameof(GetAllMenus));

        api.MapGet("/{id:guid}", GetMenuById.Execute)
            .WithName(nameof(GetMenuById));

        api.MapPost(string.Empty, CreateMenu.Execute)
            .WithName(nameof(CreateMenu));

        api.MapPut("/{id:guid}", UpdateMenu.Execute)
            .WithName(nameof(UpdateMenu));

        api.MapDelete("/{id:guid}", DeleteMenu.Execute)
            .WithName(nameof(DeleteMenu));
    }
}