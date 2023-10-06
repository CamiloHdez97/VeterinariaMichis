using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class MedicineMovementConfiguration : IEntityTypeConfiguration<MedicineMovement>
{
    public void Configure(EntityTypeBuilder<MedicineMovement> builder)
    {
        builder.ToTable("medicine_movement");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Product).WithMany(v => v.MedicineMovements).HasForeignKey(p => p.ProductId);

        builder.Property(p => p.Amount)
        .HasColumnName("amount")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Date)
        .HasColumnName("date")
        .HasColumnType("date")
        .IsRequired();
    }

}