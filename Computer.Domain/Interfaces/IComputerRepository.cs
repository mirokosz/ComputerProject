using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Domain.Interfaces
{
    public interface IComputerRepository
    {
        Task Create(Domain.Entities.Computer computer);
        Task<Domain.Entities.Computer?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Computer>> GetAll();
        Task<Domain.Entities.Computer> GetByEncodedName(string encodedName);
        Task Commit();

    }
}
