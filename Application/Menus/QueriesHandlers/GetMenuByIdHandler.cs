using Application.Abstractions;
using Application.Menus.Queries;
using Application.Menus.Responses;
using MediatR;

namespace Application.Menus.QueriesHandlers;

public class GetMenuByIdHandler(IMenuRepository repository) : IRequestHandler<GetMenuByIdQuery, MenuResponse>
{
    public async Task<MenuResponse> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
    {
        var menu = await repository.GetMenuById(request.Id, cancellationToken);
        return menu!;
    }
}