using System.ComponentModel.DataAnnotations;
namespace Core.Entities;
public class MedicalTreatment : BaseEntity
{
    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public string Dose { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

}