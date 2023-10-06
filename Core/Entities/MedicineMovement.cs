using System.Net.Http.Headers;
namespace Core.Entities;
public class MedicineMovement : BaseEntity
 {
    public int ProductId {get; set; }
    public Product Product {get; set; }
    public int Amount {get; set; }
    public DateTime Date {get; set; }
    public ICollection<MovementDetail> MovementDetails {get; set; }
 
}