using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.EntityFramework.Context;

public class BackenDbContext : DbContext
{
    public DbSet<UserEntity> User { get; set; }
    public DbSet<ProductEntity> Product { get; set; }
    public DbSet<OrderEntity> Order { get; set; }
    public DbSet<ProductOrderEntity> ProductOrder { get; set; }
    
    public BackenDbContext(DbContextOptions<BackenDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new ProductOrderConfiguration());
        base.OnModelCreating(builder);
    }
}