namespace Core.Entities;

public class Pet : BaseEntity
{
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
    public int RaceId { get; set; }
    public Race Race { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<Appointment> Appointments { get; set; }


}
