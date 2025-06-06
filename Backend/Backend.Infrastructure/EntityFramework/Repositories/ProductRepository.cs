using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using Backend.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.EntityFramework.Repositories;

public class ProductRepository : IProductRepository
{
    
    private readonly BackenDbContext _context;

    public ProductRepository(BackenDbContext context)
    {
        _context = context;
    }
    
    public async Task<ProductEntity?> GetByIdAsync(int id)
    {
        return await _context.Product.FindAsync(id);
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Product.ToListAsync();
    }

    public async Task AddAsync(ProductEntity product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductEntity product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product != null)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}