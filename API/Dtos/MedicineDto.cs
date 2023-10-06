namespace API.Dtos;

public class MedicineDto
{
    public int ID_medicamento { get; set; }
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; } 
    public double Precio { get; set; }
    public int ID_Laboratorio  { get; set; }

}