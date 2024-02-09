using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computer.Domain.Interfaces;
using MediatR;
using AutoMapper;

namespace Computer.Application.Computer.Commands.CreateComputer
{
    public class CreateComputerCommandHandler : IRequestHandler<CreateComputerCommand>
    {
        private readonly IComputerRepository _computerRepository;
        private readonly IMapper _mapper;

        public CreateComputerCommandHandler(IComputerRepository computerRepository, IMapper mapper)
        {
            _computerRepository = computerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateComputerCommand request, CancellationToken cancellationToken) 
        {
            var computer = _mapper.Map<Domain.Entities.Computer>(request);

            computer.EncodeName();
            await _computerRepository.Create(computer);
            return Unit.Value;
        }
    }
}
