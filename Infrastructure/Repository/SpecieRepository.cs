using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class SpecieRepository : GenericRepository<Specie>, ISpecie
{
    private readonly ApiDbContext _context;
    public SpecieRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
