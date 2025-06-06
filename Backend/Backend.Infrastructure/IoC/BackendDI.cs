using Backend.Application.Services;
using Backend.Domain.Repositories;
using Backend.Infrastructure.EntityFramework.Context;
using Backend.Infrastructure.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure.IoC;

public static class BackendDI
{
    public static IServiceCollection RegisterDataBase(this IServiceCollection collection, IConfiguration configuration)
    {
        string connectionString = configuration["ConnectionStrings:localConnection"];
        collection.AddDbContext<BackenDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }
        );
        return collection;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        //add your Services
        //Activity
        collection.AddTransient<UserService>();
        return collection;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection collection)
    {
        collection.AddTransient<IUserRepository, UserRepository>();
        return collection;
    }
}