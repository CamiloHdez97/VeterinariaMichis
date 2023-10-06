using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class VetRepository : GenericRepository<Vet>, IVet
{
    private readonly ApiDbContext _context;
    public VetRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
    
}
