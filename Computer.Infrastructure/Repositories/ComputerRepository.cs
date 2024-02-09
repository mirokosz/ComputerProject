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

        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.Computer computer)
        {
            _dbContext.Add(computer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Computer>> GetAll()
            => await _dbContext.Computers.ToListAsync();
        public async Task<Domain.Entities.Computer> GetByEncodedName(string encodedName)
         => await _dbContext.Computers.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.Computer?> GetByName(string name)
            => _dbContext.Computers.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
