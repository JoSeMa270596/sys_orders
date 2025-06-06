using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.EntityFramework.Context;

public class BackenDbContextFactory : IDesignTimeDbContextFactory<BackenDbContext>
{
    public BackenDbContext CreateDbContext(string[] args)
    {

        var basePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..","Api");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();
        
        
        var connectionString = configuration.GetConnectionString("localConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "La cadena de conexión no puede ser nula ni estar vacía.");
        }
        var optionsBuilder = new DbContextOptionsBuilder<BackenDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new BackenDbContext(optionsBuilder.Options);
    }
}