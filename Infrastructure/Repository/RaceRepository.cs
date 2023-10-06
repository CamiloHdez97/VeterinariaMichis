using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class RaceRepository : GenericRepository<Race>, IRace
{
    private readonly ApiDbContext _context;
    public RaceRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
