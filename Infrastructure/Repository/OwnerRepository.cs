using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class OwnerRepository : GenericRepository<Owner>, IOwner
{
    private readonly ApiDbContext _context;
    public OwnerRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
