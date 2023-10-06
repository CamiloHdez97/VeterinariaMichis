using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApiDbContext : DbContext
{
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }


             public DbSet<User> Users { get; set; }
             public DbSet<Rol>  Rols { get; set; }
             public DbSet<UserRol> UsersRols { get; set; }
             public DbSet<Appointment> Appointments {get;set;}  
             public DbSet<Laboratory> Laboratories {get;set;}  
             public DbSet<MedicalTreatment> MedicalTreatments {get;set;}  
             public DbSet<Medicine> Medicines {get;set;}  
             public DbSet<MedicineMovement> MedicineMovements {get;set;}  
             public DbSet<MovementDetail> MovementDetails {get;set;}  
             public DbSet<Owner> Owners {get;set;}  
             public DbSet<Pet> Pets {get;set;}  
             public DbSet<Product> Products {get;set;}  
             public DbSet<Race> Races {get;set;}  
             public DbSet<Specie> Species {get;set;}  
             public DbSet<Vet> Vets {get;set;}  



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

}