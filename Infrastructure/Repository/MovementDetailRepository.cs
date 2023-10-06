using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class MovementDetailRepository : GenericRepository<MovementDetail>, IMovementDetail
{
    private readonly ApiDbContext _context;
    public MovementDetailRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
