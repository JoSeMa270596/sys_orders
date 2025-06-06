using Backend.Domain.Dtos;
using Backend.Domain.Entities;

namespace Backend.Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(int id);
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task AddAsync(UserEntity user);
    Task UpdateAsync(UserEntity user);
    Task DeleteAsync(int id);
}