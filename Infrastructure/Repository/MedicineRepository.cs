using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository;
public class MedicineRepository : GenericRepository<Medicine>, IMedicine
{
    private readonly ApiDbContext _context;
    public MedicineRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
