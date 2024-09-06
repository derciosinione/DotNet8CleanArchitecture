using Application.Menus.Responses;
using MediatR;

namespace Application.Menus.Queries;

public class GetAllMenusQuery : IRequest<ICollection<MenuResponse>>;