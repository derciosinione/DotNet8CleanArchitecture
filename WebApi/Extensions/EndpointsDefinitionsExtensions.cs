using WebApi.Abstractions;

namespace WebApi.Extensions;

public static class EndpointsDefinitionsExtensions
{
    public static void RegisterApiEndpoints(this WebApplication app)
    {
        var endpoints = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinitions)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinitions>();

        foreach (var endpoint in endpoints) endpoint.RegisterEndpoints(app);
    }
}