using System.ComponentModel.DataAnnotations;
namespace Core.Entities;
public class Appointment : BaseEntity
{
    public int PetId { get; set; }
    public Pet Pet { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set;} 
    public string Description { get; set; }
    public int VetId { get; set; }
    public Vet Vet { get; set; }
    public ICollection<MedicalTreatment> MedicalTreatments { get; set; }

}