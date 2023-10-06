using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>
{
    public void Configure(EntityTypeBuilder<Laboratory> builder)
    {
        builder.ToTable("laboratory");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Name)
        .HasColumnName("name")
        .HasColumnType("varchar")
        .IsRequired();

        builder.Property(p => p.Location)
        .HasColumnName("location")
        .HasColumnType("varchar")
        .IsRequired();

        builder.Property(p => p.Phone)
        .HasColumnName("phone")
        .HasColumnType("varchar")
        .IsRequired();

    }

}