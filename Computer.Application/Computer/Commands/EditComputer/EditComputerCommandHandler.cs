using Computer.Domain.Interfaces;
using Computer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Application.Computer.Commands.EditComputer
{
    internal class EditComputerCommandHandler : IRequestHandler<EditComputerCommand>
    {
        private readonly IComputerRepository _repository;

        public EditComputerCommandHandler(IComputerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(EditComputerCommand request, CancellationToken cancellationToken)
        {
            var computer = await _repository.GetByEncodedName(request.EncodedName!);

            computer.Producer = request.Producer;

            computer.SpecificationDetails.CPU = request.CPU;
            computer.SpecificationDetails.Memory = request.Memory;
            computer.SpecificationDetails.GPU = request.GPU;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
