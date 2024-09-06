using Application.Menus.Commands;
using WebApi.Requests;

namespace WebApi.Mapper;

public static class MenuExtensions
{
    public static CreateMenuCommand ToCommand(this CreateMenuRequest request)
    {
        return new CreateMenuCommand
        {
            Name = request.Name,
            CodeI18N = request.CodeI18N ?? string.Empty
        };
    }
}