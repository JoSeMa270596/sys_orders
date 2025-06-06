namespace Backend.Domain.Dtos;

public record ProductDto(
    string Name,
    decimal Price,
    int UserId
);