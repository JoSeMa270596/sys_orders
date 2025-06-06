using Backend.Domain.Dtos;
using Backend.Domain.Entities;
using Backend.Domain.Repositories;

namespace Backend.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserEntity> CreateAsync(UserDto dto)
    {
        var user = new UserEntity
        {
            Name = dto.Name,
            Email = dto.Email
        };

        await _userRepository.AddAsync(user);
        return user;

    }
    
    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(int id, UserDto dto)
    {
        var existing = await _userRepository.GetByIdAsync(id);
        if (existing is null)
            return false;

        existing.Name = dto.Name;
        existing.Email = dto.Email;

        await _userRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _userRepository.GetByIdAsync(id);
        if (existing is null)
            return false;

        await _userRepository.DeleteAsync(id);
        return true;
    }
}