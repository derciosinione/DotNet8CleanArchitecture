using Application.Abstractions;
using DataAccess.Repository;

namespace WebApi.Extensions;

public static class ApiExtensions
{
    public static void RegisterApiServices(this WebApplicationBuilder builder)
    {
        builder.RegisterDb();
        builder.RegisterApiMediatorInjection();
        builder.RegisterApiRepositories();

        builder.Services.AddScoped<IMenuRepository, MenuRepository>();
    }
}