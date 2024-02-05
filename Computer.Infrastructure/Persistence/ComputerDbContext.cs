using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Infrastructure.Persistence
{
    public class ComputerDbContext : DbContext    
    {
        public ComputerDbContext(DbContextOptions<ComputerDbContext> options) : base(options)
        {
            
        }
        public DbSet<Computer.Domain.Entities.Computer> Computers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ComputerDb;Trusted_Connection=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Computer>()
                .OwnsOne(c => c.SpecificationDetails);
        }
    }
}
