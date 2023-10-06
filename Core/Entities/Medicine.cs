namespace Core.Entities;

public class Medicine : BaseEntity{

    public string Name { get; set; }
    public int Stock { get; set; } 
    public double Price { get; set; }
    public int LaboratoryId { get; set; }
    public Laboratory Laboratory { get; set; }
    public ICollection<Supplier> Suppliers {get;set;} = new HashSet<Supplier>(); 
    public ICollection<MedicineSupplier> MedicineSuppliers { get; set; }
    public ICollection<MedicalTreatment> MedicalTreatments { get; set; }

}