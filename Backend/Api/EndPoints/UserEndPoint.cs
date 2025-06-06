using Backend.Application.Services;
using Backend.Domain.Dtos;
using Backend.Domain.Entities;

namespace Api.EndPoints;

public static class UserEndPoint
{
    internal static void MapUserEndPoint(this WebApplication webApp)
    {
        webApp.MapGroup("/users").WithTags("Usuarios").MapGroupEnpoint();
    }

    private static void MapGroupEnpoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(
            "",
            async (UserDto dto, UserService service) =>
            {
                var createdUser = await service.CreateAsync(dto);
                return Results.Created($"/users/{createdUser.Id}", createdUser);
            }
        );
        
        groupBuilder.MapGet(
            "",
            async (UserService service) =>
            {
                var users = await service.GetAllAsync();
                return Results.Ok(users);
            }
        );
        
        groupBuilder.MapGet(
            "{id:int}",
            async (int id, UserService service) =>
            {
                var user = await service.GetByIdAsync(id);
                return user is null ? Results.NotFound() : Results.Ok(user);
            }
        );
        
        groupBuilder.MapPut(
            "{id:int}",
            async (int id, UserDto dto, UserService service) =>
            {
                var success = await service.UpdateAsync(id, dto);
                return success ? Results.NoContent() : Results.NotFound();
            }
        );
        
        groupBuilder.MapDelete(
            "{id:int}",
            async (int id, UserService service) =>
            {
                var success = await service.DeleteAsync(id);
                return success ? Results.NoContent() : Results.NotFound();
            }
        );
    }
    
    
}