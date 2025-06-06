using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.EntityFramework.Context;

public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrderEntity>
{
    public void Configure(EntityTypeBuilder<ProductOrderEntity> builder)
    {
        builder.ToTable("ProductOrder")
            .HasComment("Tabla de relación entre productos y órdenes");
        
        // Configuración de clave primaria compuesta
        builder.HasKey(po => new { po.OrderId, po.ProductId });
            
        // Configuración de la cantidad
        builder.Property(po => po.Quantity)
            .HasColumnName("quantity")
            .IsRequired();
            
        // Configuración de la relación con Order
        builder.HasOne(po => po.Order)
            .WithMany(o => o.ProductOrders)
            .HasForeignKey(po => po.OrderId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductOrder_Order");
            
        // Configuración de la relación con Product
        builder.HasOne(po => po.Product)
            .WithMany(p => p.ProductOrders)
            .HasForeignKey(po => po.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ProductOrder_Product");
    }
}