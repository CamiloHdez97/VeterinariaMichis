using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pet");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Owner).WithMany(v => v.Pets).HasForeignKey(p => p.OwnerId);
        
        builder.HasOne(p => p.Specie).WithMany(v => v.Pets).HasForeignKey(p => p.SpecieId);

        builder.HasOne(p => p.Race).WithMany(v => v.Pets).HasForeignKey(p => p.RaceId);

        builder.Property(p => p.Name)
        .HasColumnName("name")
        .HasColumnType("varchar")
        .IsRequired();

        builder.Property(p => p.BirthDate)
        .HasColumnName("brithdate")
        .HasColumnType("date")
        .IsRequired();
    
    }

}