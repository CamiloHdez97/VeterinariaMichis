namespace Core.Entities;

public class Specie : BaseEntity
{
    public string Name { get; set; }
    
    //public ICollection<Race> Races { get; set; }
    public ICollection<Pet> Pets { get; set; }
    
}