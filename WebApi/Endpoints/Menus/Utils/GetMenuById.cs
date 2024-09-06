using Application.Menus.Queries;
using MediatR;

namespace WebApi.Endpoints.Menus.Utils;

public static class GetMenuById
{
    public static async Task<IResult> Execute(ISender mediator, Guid id, CancellationToken cancellationToken)
    {
        var query = new GetMenuByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        return result == null! ? TypedResults.NotFound() : TypedResults.Ok(result);
    }
}