using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Infrastructure.Persistence
{
    public class ComputerDbContext : IdentityDbContext    
    {
        public ComputerDbContext(DbContextOptions<ComputerDbContext> options) : base(options)
        {
            
        }
        public DbSet<Computer.Domain.Entities.Computer> Computers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.Computer>()
                .OwnsOne(c => c.SpecificationDetails);
        }
    }
}
