using Application.Menus.Commands;
using Application.Menus.Responses;

namespace DataAccess.Mapper.Menu;

public static class MenuExtensions
{
    public static Domain.Models.Menu ToMenu(this CreateMenuCommand request)
    {
        return new Domain.Models.Menu(request.Name, request.CodeI18N!);
    }

    public static void UpdateFromCommand(this Domain.Models.Menu menu, UpdateMenuCommand command)
    {
        // menu.UpdatedAt = DateTime.Now;
        menu.Name = !string.IsNullOrWhiteSpace(command.Name) ? command.Name : menu.Name;
        menu.CodeI18N = !string.IsNullOrWhiteSpace(command.CodeI18N) ? command.CodeI18N : menu.CodeI18N;
    }

    public static MenuResponse? ToMenuResponse(this Domain.Models.Menu? menu)
    {
        if (menu is null) return null;

        return new MenuResponse
        {
            Id = menu.Id,
            Name = menu.Name,
            CodeI18N = menu.CodeI18N,
            Level = menu.Level,
            CreatedAt = menu.CreatedAt,
            UpdatedAt = menu.UpdatedAt
        };
    }

    public static ICollection<MenuResponse> ToMenuResponses(this IEnumerable<Domain.Models.Menu> menus)
    {
        var enumerable = menus.ToList();

        if (enumerable.Count == 0)
            return new List<MenuResponse>();

        return enumerable.Select(menu => new MenuResponse
        {
            Id = menu.Id,
            Name = menu.Name,
            CodeI18N = menu.CodeI18N,
            Level = menu.Level,
            CreatedAt = menu.CreatedAt,
            UpdatedAt = menu.UpdatedAt
        }).ToList();
    }
}