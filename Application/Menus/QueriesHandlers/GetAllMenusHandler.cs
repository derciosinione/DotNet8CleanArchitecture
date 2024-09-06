using Application.Abstractions;
using Application.Menus.Queries;
using Application.Menus.Responses;
using MediatR;

namespace Application.Menus.QueriesHandlers;

public class GetAllMenusHandler(IMenuRepository repository)
    : IRequestHandler<GetAllMenusQuery, ICollection<MenuResponse>>
{
    public async Task<ICollection<MenuResponse>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
    {
        var menus = await repository.GetAllMenusAsync(cancellationToken);
        return menus;
    }
}