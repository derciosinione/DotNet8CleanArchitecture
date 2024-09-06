using Application.Menus.Responses;
using MediatR;

namespace Application.Menus.Queries;

public class GetMenuByIdQuery(Guid postId) : IRequest<MenuResponse>
{
    public Guid Id { get; } = postId;
}