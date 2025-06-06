using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.EntityFramework.Context;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        
        builder.ToTable("Product")
            .HasComment("Tabla de productos");
            
        // Configuración de la clave primaria
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
            
        // Configuración del nombre
        builder.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(250);
            
        // Configuración de precios y tasas
        builder.Property(p => p.PriceBs)
            .HasColumnName("priceBs")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(p => p.PriceUSD)
            .HasColumnName("priceUsd")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            
        builder.Property(p => p.ExchangeRate)
            .HasColumnName("exchangeRate")
            .HasColumnType("decimal(18,2)");
            
        // Configuración de la relación con User
        builder.HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Product_User");
    }
}