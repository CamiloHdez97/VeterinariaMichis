namespace Core.Entities;

public class Laboratory : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Phone { get; set; }
    public ICollection<Medicine> Medicines { get; set; }

}