using System.ComponentModel.DataAnnotations;
namespace Core.Entities;

public class Race : BaseEntity
{

    //Correción relación circular
    //public int SpecieId { get; set; }
    //public Specie Specie { get; set; }
    //  public ICollection<Race> Owners { get; set; }

    public string Name { get; set; }
    public ICollection<Pet> Pets { get; set; }



}