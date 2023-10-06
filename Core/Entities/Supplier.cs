namespace Core.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int Phone { get; set; }
    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
    public ICollection<MedicineSupplier> MedicineSuppliers { get; set; } = new List<MedicineSupplier>();

}