using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Week3.Domain;

namespace Week3.Persistence.Context;

public class VirtualPetDbContext : DbContext
{
    DbSet<User> Users { get; set; }
    public VirtualPetDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        
    }
}
