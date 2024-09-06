using Application.Menus.Responses;
using FluentResults;
using MediatR;

namespace Application.Menus.Commands;

public class UpdateMenuCommand : IRequest<Result<MenuResponse>>
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? CodeI18N { get; set; }
}