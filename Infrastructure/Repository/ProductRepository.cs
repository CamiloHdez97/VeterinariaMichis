using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;
public class ProductRepository : GenericRepository<Product>, IProduct
{
    private readonly ApiDbContext _context;
    public ProductRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
