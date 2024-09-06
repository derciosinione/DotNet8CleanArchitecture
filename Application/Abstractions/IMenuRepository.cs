using Application.Menus.Commands;
using Application.Menus.Responses;
using FluentResults;

namespace Application.Abstractions;

public interface IMenuRepository
{
    Task<ICollection<MenuResponse>> GetAllMenusAsync(CancellationToken cancellationToken = default);
    Task<MenuResponse?> GetMenuById(Guid id, CancellationToken cancellationToken = default);
    Task<Result<MenuResponse>> CreateMenu(CreateMenuCommand request, CancellationToken cancellationToken = default);
    Task<Result<MenuResponse>> UpdateMenu(Guid id, UpdateMenuCommand request, CancellationToken cancellationToken = default);
    Task<Result> DeleteMenu(Guid id, CancellationToken cancellationToken = default);
}