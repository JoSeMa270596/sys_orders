using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.EntityFramework.Context;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User")
            .HasComment("Tabla de usuarios");
        // Configuración de la clave primaria
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        // configuracion del Nombre como varchar(250)
        builder.Property(e=>e.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(250);
        // configuracion del Email como varchar(250)
        builder.Property(e=>e.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(250);
    }
}