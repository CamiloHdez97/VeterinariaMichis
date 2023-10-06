using System.ComponentModel.DataAnnotations;
namespace API.Dtos;
public class MedicalTreatmentDto
{
    public int ID_Tratamiento  { get; set; }
    public int ID_cita { get; set; }
    public int ID_medicamento { get; set; }
    public string Dosis { get; set; }
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }

}