using Barber.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Barber.API.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
      
        public DbSet<Billing> Billings { get; set; } = null!;
    }
}
