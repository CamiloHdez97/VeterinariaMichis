namespace Core.Entities;

public class Vet : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Speciality { get; set; }
    public ICollection<Appointment> Appointments { get; set; }

}