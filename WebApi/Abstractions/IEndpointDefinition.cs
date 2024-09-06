namespace WebApi.Abstractions;

public interface IEndpointDefinitions
{
    void RegisterEndpoints(WebApplication app);
}