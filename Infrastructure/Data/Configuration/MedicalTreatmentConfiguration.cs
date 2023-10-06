using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class MedicalTreatmentConfiguration : IEntityTypeConfiguration<MedicalTreatment>
{
    public void Configure(EntityTypeBuilder<MedicalTreatment> builder)
    {
        builder.ToTable("medical_treatment");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.AppointmentId)
        .HasColumnName("appointment_id")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.Dose)
        .HasColumnName("dose")
        .HasColumnType("varchar")
        .IsRequired();

        builder.Property(p => p.Date)
        .HasColumnName("date")
        .HasColumnType("Date")
        .IsRequired();

        builder.Property(p => p.Description)
        .HasColumnName("description")
        .HasColumnType("varchar")
        .IsRequired();

    }

}