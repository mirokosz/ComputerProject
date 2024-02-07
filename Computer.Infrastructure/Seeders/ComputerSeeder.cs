using Computer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Infrastructure.Seeders
{
    public class ComputerSeeder
    {
        private readonly ComputerDbContext _dbContext;
        public ComputerSeeder(ComputerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Computers.Any())
                {
                    var GameXG300 = new Domain.Entities.Computer()
                    {
                        Name = "GameXG300",
                        Producer = "Morele.net",
                        SpecificationDetails = new()
                        {
                            CPU = "Core i5-13400F",
                            Memory = "32GB",
                            GPU = "RTX 4060 Ti"
                        }
                    };
                    GameXG300.EncodeName();
                    _dbContext.Computers.Add(GameXG300);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
