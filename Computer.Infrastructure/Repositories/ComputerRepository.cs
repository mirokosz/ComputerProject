using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computer.Domain.Interfaces;
using Computer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Computer.Infrastructure.Repositories
{
    internal class ComputerRepository : IComputerRepository
    {
        private readonly ComputerDbContext _dbContext;
        public ComputerRepository(ComputerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.Computer computer)
        {
            _dbContext.Add(computer);
            await _dbContext.SaveChangesAsync();
        }
        public Task<Domain.Entities.Computer?> GetByName(string name)
            => _dbContext.Computers.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
