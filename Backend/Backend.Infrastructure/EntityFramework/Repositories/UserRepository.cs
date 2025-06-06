using Backend.Domain.Dtos;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;
using Backend.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.EntityFramework.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BackenDbContext _context;

    public UserRepository(BackenDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task AddAsync(UserEntity user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserEntity user)
    {
        
        _context.User.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}