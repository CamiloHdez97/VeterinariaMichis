using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");


        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("id_user")
        .HasColumnType("int")
        .IsRequired();


        builder.Property(p => p.Name_User)
        .HasColumnName("name_user")
        .HasColumnType("varchar")
        .IsRequired();


        builder.Property(p => p.Password)
       .HasColumnName("password")
       .HasColumnType("varchar")
       .IsRequired();

        builder.Property(p => p.Email)
        .HasColumnName("email")
        .HasColumnType("varchar")
        .IsRequired();

        builder
       .HasMany(p => p.Rols)
       .WithMany(r => r.Users)
       .UsingEntity<UserRol>(

           j => j
           .HasOne(pt => pt.Rol)
           .WithMany(t => t.UserRols)
           .HasForeignKey(ut => ut.RolId),


           j => j
           .HasOne(et => et.User)
           .WithMany(et => et.UserRols)
           .HasForeignKey(el => el.UserId),

           j =>
           {
               j.HasKey(t => new { t.UserId, t.RolId });

           });

            builder.HasData(
                new User
                {
                    Id = 1,
                    Name_User = "camilo",
                    Password = "1234",
                    Email = "camilo@gmail.com"
                },
                new User
                {
                    Id = 2,
                    Name_User = "jose",
                    Password = "1234",
                    Email = "jose@gmail.com"
                },
                 new User
                {
                    Id = 3,
                    Name_User = "karepan",
                    Password = "1234",
                    Email = "karepan@gmail.com"
                }

            );



    }
}