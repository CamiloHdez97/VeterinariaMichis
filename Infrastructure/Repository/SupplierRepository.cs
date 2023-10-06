using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class SupplierRepository : GenericRepository<Supplier>, ISupplier
{
    private readonly ApiDbContext _context;
    public SupplierRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
