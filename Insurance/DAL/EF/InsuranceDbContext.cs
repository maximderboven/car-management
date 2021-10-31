using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Insurance.Domain;

namespace Insurance.DAL.EF
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Garage> Garages { get; set; }

        public InsuranceDbContext()
        {
            
            InsuranceInitializer.Initialize(this,false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../../../../database.db");
            optionsBuilder.LogTo(p => Debug.WriteLine(p), LogLevel.Information);
        }
    }
}