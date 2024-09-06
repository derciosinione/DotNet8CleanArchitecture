using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions;

public static class DbInjectionExtension
{
    public static void RegisterDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!));
    }
}