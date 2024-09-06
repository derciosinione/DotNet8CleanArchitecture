using FluentResults;
using MediatR;

namespace Application.Menus.Commands;

public class DeleteMenuCommand(Guid id) : IRequest<Result>
{
    public Guid Id { get; } = id;
}