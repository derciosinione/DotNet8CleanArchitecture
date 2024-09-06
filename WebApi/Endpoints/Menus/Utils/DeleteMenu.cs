using Application.Menus.Commands;
using MediatR;

namespace WebApi.Endpoints.Menus.Utils;

public static class DeleteMenu
{
    public static async Task<IResult> Execute(Guid id, ISender mediator, CancellationToken cancellationToken)
    {
        var query = new DeleteMenuCommand(id);
        var result = await mediator.Send(query, cancellationToken);
        
        return result.IsSuccess ? TypedResults.NoContent() : TypedResults.BadRequest(result.Errors);
    }
}