using MediatR;
using WebApi.Mapper;
using WebApi.Requests;

namespace WebApi.Endpoints.Menus.Utils;

public static class CreateMenu
{
    public static async Task<IResult> Execute(CreateMenuRequest request, ISender mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.ToCommand(), cancellationToken);

        return !result.IsSuccess
            ? Results.BadRequest(result.Errors)
            : Results.CreatedAtRoute(nameof(GetMenuById), new { result.Value.Id }, result.Value);
    }
}