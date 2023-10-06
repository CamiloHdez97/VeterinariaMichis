namespace Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public ICollection<MedicineMovement> MedicineMovements { get; set;}
    public ICollection<MovementDetail> MovementDetails { get; set;}
}