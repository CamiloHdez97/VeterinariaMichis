using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratory
{
    private readonly ApiDbContext _context;
    public LaboratoryRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
