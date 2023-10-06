namespace Core.Interfaces;
public interface IUnitOfWork
{
    IAppointment Appointments { get; }
    ILaboratory Laboratories { get; }
    IMedicalTreatment MedicalTreatments { get; }
    IMedicine Medicines { get; }
    IMedicineMovement MedicineMovements { get; }
    IMovementDetail MovementDetails { get; }
    IOwner Owners { get; }
    IPet Pets { get; }
    IProduct Products { get; }
    IRace Races { get; }
    ISpecie Species { get; }
    ISupplier Suppliers { get; }
    IVet Vets { get; }
    IRol Rols {get;} 
    IUser Users {get;} 

    Task<int> SaveAsync();
}