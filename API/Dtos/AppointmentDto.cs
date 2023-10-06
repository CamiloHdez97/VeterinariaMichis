namespace API.Dtos;
public class AppointmentDto
{
    public int ID_Cita  { get; set; }
    public int ID_Mascota  { get; set; }
    public DateTime Fecha { get; set; }
    public string Hora { get; set;} 
    public string Motivo { get; set; }
    public int ID_Veterinario { get; set; }


}