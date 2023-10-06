
namespace API.Dtos;

public class MovementDetailDto
{
    public int ID_Salida  { get; set; }
    public int ID_Producto   { get; set; }
    public int Cantidad { get; set; }
    public int ID_MovMed { get; set; }
    public double Precio { get; set; }

}