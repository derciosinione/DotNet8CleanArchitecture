using Application.Abstractions;
using Application.Menus.Commands;
using Application.Menus.Responses;
using FluentResults;
using MediatR;

namespace Application.Menus.CommandHandlers;

public class CreateMenuHandler(IMenuRepository repository) : IRequestHandler<CreateMenuCommand, Result<MenuResponse>>
{
    public async Task<Result<MenuResponse>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        return await repository.CreateMenu(request, cancellationToken);;
    }
}