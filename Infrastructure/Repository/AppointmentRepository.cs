using System.Diagnostics;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Infrastructure.Repository;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointment
{
    private readonly ApiDbContext _context;
    public AppointmentRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

}
