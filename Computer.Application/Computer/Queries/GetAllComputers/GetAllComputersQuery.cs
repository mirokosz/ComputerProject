using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Application.Computer.Queries.GetAllComputers
{
    public class GetAllComputersQuery :IRequest<IEnumerable<ComputerDto>>
    {
    }
}
