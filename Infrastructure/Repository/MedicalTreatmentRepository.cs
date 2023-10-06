using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class MedicalTreatmentRepository : GenericRepository<MedicalTreatment>, IMedicalTreatment
{
    private readonly ApiDbContext _context;
    public MedicalTreatmentRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
