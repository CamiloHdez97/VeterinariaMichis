
namespace Core.Entities;

public class MovementDetail : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; }
    public int MedicineMovementId { get; set; }
    public MedicineMovement MedicineMovement { get; set; }
    public double Price { get; set; }

}