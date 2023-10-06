using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("appointment");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Pet).WithMany(v => v.Appointments).HasForeignKey(p => p.PetId);

        builder.Property(p => p.Date)
        .HasColumnName("date")
        .HasColumnType("datetime")
        .IsRequired();

        builder.Property(p => p.Time)
       .HasColumnName("time")
       .HasColumnType("varchar")
       .IsRequired();

        builder.Property(p => p.Description)
        .HasColumnName("description")
        .HasColumnType("varchar")
        .IsRequired();

        builder.HasOne(p => p.Vet).WithMany(v => v.Appointments).HasForeignKey(p => p.VetId);

    }

}