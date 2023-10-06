using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable("medicine");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Name)
        .HasColumnName("name")
        .HasColumnType("varchar")
        .IsRequired();

        builder.Property(p => p.Stock)
        .HasColumnName("stock")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Price)
        .HasColumnName("price")
        .HasColumnType("double")
        .IsRequired();

        builder.HasOne(p => p.Laboratory).WithMany(v => v.Medicines).HasForeignKey(p => p.LaboratoryId);

        builder
       .HasMany(p => p.Suppliers)
       .WithMany(r => r.Medicines)
       .UsingEntity<MedicineSupplier>(

           j => j
           .HasOne(pt => pt.Supplier)
           .WithMany(t => t.MedicineSuppliers)
           .HasForeignKey(ut => ut.SupplierId),


           j => j
           .HasOne(et => et.Medicine)
           .WithMany(et => et.MedicineSuppliers)
           .HasForeignKey(el => el.MedicineId),

           j =>
           {
               j.HasKey(t => new { t.MedicineId, t.SupplierId });

           });

    }

}