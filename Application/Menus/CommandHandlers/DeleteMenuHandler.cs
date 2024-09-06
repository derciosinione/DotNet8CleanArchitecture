using Application.Abstractions;
using Application.Menus.Commands;
using FluentResults;
using MediatR;

namespace Application.Menus.CommandHandlers;

public class DeleteMenuHandler(IMenuRepository repository) : IRequestHandler<DeleteMenuCommand, Result>
{
    public Task<Result> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        return repository.DeleteMenu(request.Id, cancellationToken);
    }
}