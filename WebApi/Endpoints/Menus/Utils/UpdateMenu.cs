using Application.Menus.Commands;
using MediatR;
using WebApi.Requests;

namespace WebApi.Endpoints.Menus.Utils;

public static class UpdateMenu
{
    public static async Task<IResult> Execute(Guid id, UpdateMenuRequest request, ISender mediator,
        CancellationToken cancellationToken)
    {
        var createPost = new UpdateMenuCommand { Id = id, Name = request.Name, CodeI18N = request.CodeI18N };
        var result = await mediator.Send(createPost, cancellationToken);

        if (result.IsFailed) return TypedResults.BadRequest(result.Errors);

        return TypedResults.NoContent();
    }
}