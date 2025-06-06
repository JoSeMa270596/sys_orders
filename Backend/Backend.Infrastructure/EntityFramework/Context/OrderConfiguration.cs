using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.EntityFramework.Context;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Order")
            .HasComment("Tabla de órdenes");
            
        // Configuración de la clave primaria
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
            
        // Configuración de fechas
        builder.Property(o => o.DateOrder)
            .HasColumnName("dateOrder")
            .IsRequired();
            
        // Configuración de totales
        builder.Property(o => o.TotalBs)
            .HasColumnName("totalBs")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(o => o.TotalUSD)
            .HasColumnName("totalUsd")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        // Configuración de la relación con User
        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Order_User");
    }
}