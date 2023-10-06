using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class VetConfiguration : IEntityTypeConfiguration<Vet>
{
    public void Configure(EntityTypeBuilder<Vet> builder)
    {
        builder.ToTable("vet");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Name)
        .HasColumnName("name")
        .HasColumnType("varchar")
        .IsRequired();

        builder.Property(p => p.Email)
        .HasColumnName("email")
        .HasColumnType("varchar")
        .IsRequired();

        builder.Property(p => p.Phone)
        .HasColumnName("phone")
        .HasColumnType("varchar")
        .HasMaxLength(13)
        .IsRequired();

        builder.Property(p => p.Speciality)
        .HasColumnName("speciality")
        .HasColumnType("varchar")
        .IsRequired();
    
    }

}