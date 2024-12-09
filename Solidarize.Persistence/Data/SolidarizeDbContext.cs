using Microsoft.EntityFrameworkCore;
using Solidarize.Domain.Entites.Models;


namespace Solidarize.Persistence
{
    public class SolidarizeDbContext : DbContext
    {
        public SolidarizeDbContext( DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Donors> Donor { get; set; }
        public DbSet<Seasons> Season { get; set; }

        public DbSet<Donations> Donation { get; set; }

    }
}
