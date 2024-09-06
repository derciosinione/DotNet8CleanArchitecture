using Application.Menus.Responses;
using FluentResults;
using MediatR;

namespace Application.Menus.Commands;

public class CreateMenuCommand : IRequest<Result<MenuResponse>>
{
    public required string Name { get; init; }
    public string? CodeI18N { get; init; }
}