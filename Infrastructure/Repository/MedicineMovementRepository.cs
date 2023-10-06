using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class MedicineMovementRepository : GenericRepository<MedicineMovement>, IMedicineMovement
{
    private readonly ApiDbContext _context;
    public MedicineMovementRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
