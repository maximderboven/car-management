using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Domain;

namespace Project.DAL.EF
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Garage> Garages { get; set; }

        public ProjectDbContext()
        {
            
            ProjectInitializer.Initialize(this,false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../../../../database.db");
            optionsBuilder.LogTo(p => Debug.WriteLine(p), LogLevel.Information);
        }
    }
}