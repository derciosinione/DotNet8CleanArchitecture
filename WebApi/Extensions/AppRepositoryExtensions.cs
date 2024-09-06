using Application.Abstractions;
using DataAccess.Repository;

namespace WebApi.Extensions;

public static class AppRepositoryExtensions
{
    public static void RegisterApiRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMenuRepository, MenuRepository>();
    }
}