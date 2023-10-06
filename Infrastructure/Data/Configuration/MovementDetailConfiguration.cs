using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class MovementDetailConfiguration : IEntityTypeConfiguration<MovementDetail>
{
    public void Configure(EntityTypeBuilder<MovementDetail> builder)
    {

        builder.ToTable("movement_detail");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Product).WithMany(v => v.MovementDetails).HasForeignKey(p => p.ProductId);

        builder.Property(p => p.Amount)
        .HasColumnName("amount")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.MedicineMovement).WithMany(v => v.MovementDetails).HasForeignKey(p => p.MedicineMovementId);

        builder.Property(p => p.Price)
        .HasColumnName("price")
        .HasColumnType("double")
        .IsRequired();

    }

}