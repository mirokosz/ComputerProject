using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Computer.Application.Computer.Commands.EditComputer
{
    public class EditComputerCommand : ComputerDto, IRequest
    {
    }
}
