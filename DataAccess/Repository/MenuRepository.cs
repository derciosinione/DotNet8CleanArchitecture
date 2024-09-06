using Application.Abstractions;
using Application.Menus.Commands;
using Application.Menus.Responses;
using DataAccess.Mapper.Menu;
using Domain.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repository;

public class MenuRepository(AppDbContext dbContext, ILogger<MenuRepository> logger) : IMenuRepository
{
    public async Task<ICollection<MenuResponse>> GetAllMenusAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting all menus");

        var menus = await dbContext.Menus
            .AsNoTracking()
            .TagWithCallSite()
            .ToListAsync(cancellationToken);

        logger.LogInformation("Returning all menus with {@itemCount} items", menus.Count);
        return menus.ToMenuResponses();
    }

    public async Task<MenuResponse?> GetMenuById(Guid id, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting menu by id");

        var menu = await dbContext
            .Menus
            .AsNoTracking()
            .TagWithCallSite()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        logger.LogInformation("Returning fetched menu by id {@id}", id);
        return menu.ToMenuResponse();
    }

    public async Task<Result<MenuResponse>> CreateMenu(CreateMenuCommand request,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Creating menu {@request}", request);

        var existingMenu = await VerifyExistingMenu(request.Name, cancellationToken);
        if (existingMenu.IsFailed) return existingMenu;
            
        var menu = request.ToMenu();
        dbContext.Menus.Add(menu);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Created menu {@menu}", menu);
        return menu.ToMenuResponse()!;
    }

    public async Task<Result<MenuResponse>> UpdateMenu(Guid id, UpdateMenuCommand request,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Updating menu {@request}", request);

        var existingMenu = await VerifyExistingMenu(request.Name, cancellationToken);
        if (existingMenu.IsFailed) return existingMenu;
        
        var menu = await GetMenuByIdWithTrack(id, cancellationToken);

        if (menu is null) 
            return Result.Fail($"Menu with {id} not found");

        menu.UpdateFromCommand(request);

        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Updated menu {@menu}", menu);
        return menu.ToMenuResponse()!;
    }

    public async Task<Result> DeleteMenu(Guid id, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Deleting menu {@id}", id);

        var menu = await GetMenuByIdWithTrack(id, cancellationToken);

        if (menu is null) 
            return Result.Fail($"Menu with {id} not found");;

        dbContext.Menus.Remove(menu);

        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Deleted menu {@menu}", menu);
        return Result.Ok();
    }

    #region Helper

    private async Task<Menu?> GetMenuByIdWithTrack(Guid id, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting menu by id {@id}", id);

        return await dbContext
            .Menus
            .TagWithCallSite()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    private async Task<bool> HasMenuWithGivenName(string name, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Getting menu by name {@name}", name);
        return await dbContext.Menus.AnyAsync(x => x.Name.ToLower().Equals(name.ToLower()),
            cancellationToken);
    }
    
    private async Task<Result<MenuResponse>> VerifyExistingMenu(string name, CancellationToken cancellationToken)
    {
        if (!await HasMenuWithGivenName(name, cancellationToken)) return Result.Ok();
        
        logger.LogWarning("Menu with name {@name} already exists", name);
        return Result.Fail($"Menu with name {name} already exists, please try another name");
    }
    #endregion
}