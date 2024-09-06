using Application.Menus.Queries;
using MediatR;

namespace WebApi.Endpoints.Menus.Utils;

public static class GetAllMenus
{
    public static async Task<IResult> Execute(ISender mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllMenusQuery(), cancellationToken);
        return result == null! ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
}