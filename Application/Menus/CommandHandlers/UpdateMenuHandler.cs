using Application.Abstractions;
using Application.Menus.Commands;
using Application.Menus.Responses;
using FluentResults;
using MediatR;

namespace Application.Menus.CommandHandlers;

public class UpdateMenuHandler(IMenuRepository repository) : IRequestHandler<UpdateMenuCommand, Result<MenuResponse>>
{
    public async Task<Result<MenuResponse>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.UpdateMenu(request.Id, request, cancellationToken);
        return result;
    }
}