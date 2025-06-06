using Backend.Domain.Dtos;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;

namespace Backend.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ProductEntity> CreateAsync(ProductDto dto)
    {
        var product = new ProductEntity
        {
            Name = dto.Name,
            PriceBs = dto.Price,
            UserId = dto.UserId
        };

        await _repository.AddAsync(product);
        return product;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ProductEntity?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(int id, ProductDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return false;

        existing.Name = dto.Name;
        existing.PriceBs = dto.Price;
        existing.UserId = dto.UserId;

        await _repository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}