namespace API.Dtos;

public class PetDto
{
    public int ID_Mascota { get; set; }
    public int ID_Propietario  { get; set; }
    public int ID_Especie  { get; set; }
    public int ID_Raza  { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
}
