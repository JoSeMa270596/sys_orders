using Backend.Application.Services;
using Backend.Domain.Dtos;

namespace Api.EndPoints;

public static class ProductEndpoint
{
    internal static void MapProductEndpoint(this WebApplication app)
    {
        app.MapGroup("/products").WithTags("Productos").MapGroupEndpoints();
    }
    
    private static void MapGroupEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost(
            "",
            async (ProductDto dto, ProductService service) =>
            {
                var product = await service.CreateAsync(dto);
                return Results.Created($"/products/{product.Id}", product);
            });

        group.MapGet(
            "",
            async (ProductService service) =>
            {
                var products = await service.GetAllAsync();
                return Results.Ok(products);
            });

        group.MapGet(
            "{id:int}",
            async (int id, ProductService service) =>
            {
                var product = await service.GetByIdAsync(id);
                return product is null ? Results.NotFound() : Results.Ok(product);
            });

        group.MapPut(
            "{id:int}",
            async (int id, ProductDto dto, ProductService service) =>
            {
                var success = await service.UpdateAsync(id, dto);
                return success ? Results.NoContent() : Results.NotFound();
            });

        group.MapDelete(
            "{id:int}",
            async (int id, ProductService service) =>
            {
                var success = await service.DeleteAsync(id);
                return success ? Results.NoContent() : Results.NotFound();
            });
    }
}