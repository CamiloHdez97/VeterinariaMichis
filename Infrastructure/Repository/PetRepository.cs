using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class PetRepository : GenericRepository<Pet>, IPet
{
    private readonly ApiDbContext _context;
    public PetRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
