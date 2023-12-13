using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Week3.Domain.Entities;

namespace Week3.Persistence.Context;

public class VirtualPetDbContext : DbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Pet> Pets { get; set; }
    DbSet<Activity> Activities { get; set; }
    DbSet<HealthStatus> HealthStatuses { get; set; }
    public VirtualPetDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        
    }
}
