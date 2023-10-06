using Infrastructure.Repository;
using Core.Interfaces;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRol _rols;
    private IUser _users;
    private IAppointment _appointments;
    private ILaboratory _laboratories;
    private IMedicalTreatment _medicalTreatments;
    private IMedicine _medicines;
    private IMedicineMovement _medicineMovements;
    private IMovementDetail _movementDetails;
    private IOwner _owners;
    private IPet _pets;
    private IProduct _products;
    private IRace _races;
    private ISpecie _species;
    private ISupplier _suppliers;
    private IVet _vets;

    
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }

    public IUser Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }
    

   public IRol Rols
    {
        get
        {
            _rols ??= new RolRepository(_context);
            return _rols;
        }
    }

    public IAppointment Appointments
    {
        get
        {
            _appointments ??= new AppointmentRepository(_context);
            return _appointments;
        }
    }

    public ILaboratory Laboratories    
    {
        get
        {
            _laboratories ??= new LaboratoryRepository(_context);
            return _laboratories;
        }
    }
    public IMedicalTreatment MedicalTreatments
    {
        get
        {
            _medicalTreatments ??= new MedicalTreatmentRepository(_context);
            return _medicalTreatments;
        }
    }

    public IMedicine Medicines
    {
        get
        {
            _medicines ??= new MedicineRepository(_context);
            return _medicines;
        }
    }

    public IMedicineMovement MedicineMovements
    {
        get
        {
            _medicineMovements ??= new MedicineMovementRepository(_context);
            return _medicineMovements;
        }
    }

    public IMovementDetail MovementDetails
    {
        get
        {
            _movementDetails ??= new MovementDetailRepository(_context);
            return _movementDetails;
        }
    }

    public IOwner Owners
    {
        get
        {
            _owners ??= new OwnerRepository(_context);
            return _owners;
        }
    }

    public IPet Pets
    {
        get
        {
            _pets ??= new PetRepository(_context);
            return _pets;
        }
    }
    public IProduct Products
    {
        get
        {
            _products ??= new ProductRepository(_context);
            return _products;
        }
    }

    public IRace Races
    {
        get
        {
            _races ??= new RaceRepository(_context);
            return _races;
        }
    }

    public ISpecie Species
    {
        get
        {
            _species ??= new SpecieRepository(_context);
            return _species;
        }
    }

    public IVet Vets
    {
        get
        {
            _vets ??= new VetRepository(_context);
            return _vets;
        }
    }

    public ISupplier Suppliers
    {
        get
        {
            _suppliers ??= new SupplierRepository(_context);
            return _suppliers;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}